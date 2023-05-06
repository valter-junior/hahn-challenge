using hahn.Domain.Entities;
using hahn.Domain.Enums;

namespace hahn.Service.Models
{
    public class AuthenticateModel
    {
        public AuthenticateModel(string Token, UserModel User, DateTime Expires, int StatusCode)
        {
            this.Token = Token;
            this.User = User;
            this.Expires = Expires;
            this.StatusCode = StatusCode;
        }

        public string Token { get; set; }
        public UserModel User { get; set; }
        public DateTime Expires { get; set; }
        public int StatusCode { get; set; }
    }

    public class UserModel
    {
        public UserModel(ApplicationUser user)
        {
            this.Id = user.Id;
            this.Name = user.Name;
            this.Email = user.Email;
            this.UserType = user.UserType;
            this.PhoneNumber = user.PhoneNumber;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public eUserType UserType { get; set; }
        public string PhoneNumber { get; set; }

    }

    public class SignInModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
