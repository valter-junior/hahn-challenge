using hahn.Domain.Entities;
using hahn.Infrastructure.Helpers;
using hahn.Infrastructure.Repositories;
using hahn.Infrastructure.Repository.User;
using hahn.Service.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Service.Services
{
    public class AuthService : IAuthService
    {
        public IConfiguration configuration { get; }
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly IUserRepository _repository;

        public AuthService(IConfiguration Configuration, SignInManager<ApplicationUser> signinManager, IUserRepository userRepository)
        {
            configuration = Configuration;
            _signManager = signinManager;
            _repository = userRepository;
        }

        public SecurityToken GenerateToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration.GetSection("TokenAuthentication")["SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Authentication, user.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = configuration.GetSection("TokenAuthentication")["Issuer"],
                Audience = configuration.GetSection("TokenAuthentication")["Audience"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return token;
        }

        public async Task<ResponseModel<AuthenticateModel>> GetTokenAsync(SignInModel usr)
        {
            var user = await _repository.GetByEmail(usr.Email);

            var result = await _signManager.PasswordSignInAsync(user, usr.Password, false, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                var defaultToken = GenerateToken(user);

                return ResponseBuilder.OkResponse(new AuthenticateModel(
                    new JwtSecurityTokenHandler().WriteToken(defaultToken),
                    new UserModel(user),
                    defaultToken.ValidTo,
                    200

                ));
            }
            else
            {
                return ResponseBuilder.UnauthorizedResponse().WithMessage("User or password incorrect.");
            }
        }

    }
}


