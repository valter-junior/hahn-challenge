using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using hahn.Service.Services;
using hahn.Infrastructure.Helpers;

namespace hahn.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class ManagerController : ControllerBase
    {

        private readonly IManagerService _managerService;
        private readonly RoleManager<IdentityRole> _roleManager;
      
        public ManagerController(IManagerService managerService,
           RoleManager<IdentityRole> roleManager)
        {
            
            _roleManager = roleManager;
            _managerService = managerService;

        }

        [HttpGet]
        [Route("add-manager")]
        public async Task<IActionResult> CreateRolesAndMasterUser()
        {
            try
            {
                string[] roleNames = { "Buyer", "Manager" };
                IdentityResult roleResult;
                foreach (var roleName in roleNames)
                {
                    var roleExist = await _roleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }

                var createPowerUser = await _managerService.AddAsync();

                return createPowerUser;
            }
            catch (Exception e)
            {
                return ResponseBuilder.ErrorResponse().WithMessage(e.Message);
            }

        }
    }
}
