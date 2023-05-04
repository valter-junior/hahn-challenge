using hahn.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using hahn.Infrastructure.Context;
using hahn.Domain.Enums;

namespace hahn.Application.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public IConfiguration configuration { get; }

        public ManagerController(IConfiguration Configuration, UserManager<ApplicationUser> userManager, ApplicationDbContext context, SignInManager<ApplicationUser> signinManager,
           RoleManager<IdentityRole> roleManager)
        {
            configuration = Configuration;
            _userManager = userManager;
            _db = context;
            _roleManager = roleManager;

        }

        [HttpGet]
        [Route("admincreate")]
        public async Task<ActionResult<string>> CreateRolesAndMasterUser()
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

                Manager poweruser = new()
                {
                    Name = "Manager",
                    UserName = "Manager",
                    Email = "test@hahn.io",
                    UserType = eUserType.Manager,
                    EmailConfirmed = true,

                };

                var createPowerUser = await _userManager.CreateAsync(poweruser, "hahn123");
                await _db.SaveChangesAsync();
                return "Manager created";
            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }
    }
}
