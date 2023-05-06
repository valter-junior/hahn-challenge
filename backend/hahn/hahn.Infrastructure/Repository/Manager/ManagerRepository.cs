using hahn.Domain.Entities;
using hahn.Domain.Entities.BuyerAggregate;
using hahn.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace hahn.Infrastructure.Repositories
{
    public class ManagerRepository: IManagerRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ManagerRepository(ApplicationDbContext db, UserManager<ApplicationUser> UserManager)
        {
            _db = db;
            _userManager = UserManager;
        }

        public async Task<IdentityResult> AddManagerAsync(Manager manager, string password)
        {

            return await _userManager.CreateAsync(manager, password);
        }

        public async Task<bool> VerifyIfEmailIsUnique(string email)
        {
            var result = await _db.Manager.AnyAsync(x => string.Equals(x.Email.ToLower(), email.ToLower()));
            return result;
        }

      
    }
}
