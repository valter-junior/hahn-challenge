using hahn.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using hahn.Domain.Entities.BuyerAggregate;
using hahn.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace hahn.Infrastructure.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public BuyerRepository(ApplicationDbContext db, UserManager<ApplicationUser> UserManager)
        {
            _db = db;
            _userManager = UserManager;

        }

        public async Task<IEnumerable<Buyer>> GetAllAsync(params Expression<Func<Buyer, object>>[] includes)
        {
            return await _db.Buyers.ToListAsync();
        }

        public async Task<Buyer?> GetByIdAsync(string? id, params Expression<Func<Buyer, object>>[] includes)
        {

            var search = _db.Buyers.Where(x => x.Id == id);

            return await search.FirstOrDefaultAsync();
        }

        public async Task<bool> VerifyIfEmailIsUnique(string email)
        {
            var result = await _db.Buyers.AnyAsync(x => string.Equals(x.Email.ToLower(), email.ToLower()));
            return result;
        }

        public async Task<Buyer> AddAsync(Buyer entity)
        {

            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<IdentityResult> AddBuyerAsync(Buyer buyer, string password)
        {

            return await _userManager.CreateAsync(buyer, password);
        }


        public async Task<Buyer> UpdateAsync(Buyer entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<Buyer> DeleteAsync(Buyer entity)
        {

            _db.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;

        }
    }
}
