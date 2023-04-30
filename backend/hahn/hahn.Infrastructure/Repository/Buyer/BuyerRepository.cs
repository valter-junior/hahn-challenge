using hahn.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using hahn.Domain.Entities.BuyerAggregate;


namespace hahn.Infrastructure.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly ApplicationDbContext _db;

        public BuyerRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Buyer>> GetAllAsync(params Expression<Func<Buyer, object>>[] includes)
        {
            return await _db.Buyers.ToListAsync();
        }
        public async Task<Buyer> AddAsync(Buyer entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<Buyer> UpdateAsync(Buyer entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<string> DeleteAsync(Buyer entity)
        {
            try
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
                return "Success!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
