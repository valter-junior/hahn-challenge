using hahn.Domain.Entities;
using hahn.Infrastructure.Context;
using hahn.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace hahn.Infrastructure.Repository.User
{
    public class UserRepository: IUserRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(ApplicationDbContext db, UserManager<ApplicationUser> UserManager)
        {
            _db = db;
            _userManager = UserManager;
        }

        public static IQueryable<ApplicationUser> GetIncludes(IQueryable<ApplicationUser> users, params Expression<Func<ApplicationUser, object>>[] includes)
        {
            if (includes != null)
                users = includes.Aggregate(users, (current, include) => current.Include(include.AsPath()));

            return users;
        }

        public async Task<ApplicationUser> GetByEmail(string email, params Expression<Func<ApplicationUser, object>>[] includes)
        {
            var result = _db.Users.Where(x => x.Email == email);
            return await GetIncludes(result, includes).FirstOrDefaultAsync();
        }
    }
}
