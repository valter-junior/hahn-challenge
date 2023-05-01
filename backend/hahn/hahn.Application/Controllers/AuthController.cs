using hahn.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace hahn.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;


        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }
    }
}
