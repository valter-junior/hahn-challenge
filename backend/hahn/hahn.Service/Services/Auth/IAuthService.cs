using hahn.Infrastructure.Helpers;
using hahn.Service.Models;

namespace hahn.Service.Services
{
    public interface IAuthService
    {
        Task<ResponseModel<AuthenticateModel>> GetTokenAsync(SignInModel usr);
    }
}
