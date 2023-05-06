using hahn.Domain.Entities;
using hahn.Service.Models;
using hahn.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace hahn.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController
    {

        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {

            _authService = authService;
        }

        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> GetToken([FromBody] SignInModel usr)
        {
            return await _authService.GetTokenAsync(usr);
        }
    }
}
