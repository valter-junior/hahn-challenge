using hahn.Domain.Entities;
using hahn.Domain.Entities.BuyerAggregate;
using hahn.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Infrastructure.Repositories
{
    public class ManagerRepository
    {
        private readonly ApplicationDbContext _db;

        public ManagerRepository(ApplicationDbContext db)
        {
            _db = db;
        }

      
        public async Task<Manager> AddAsync(Manager entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

    }
}
