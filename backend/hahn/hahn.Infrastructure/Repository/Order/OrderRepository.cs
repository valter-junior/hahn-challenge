using hahn.Domain.Entities.BuyerAggregate;
using hahn.Domain.Entities.OrderAggregate;
using hahn.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Infrastructure.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Order>> GetAllAsync(params Expression<Func<Order, object>>[] includes)
        {
            return await _db.Orders.ToListAsync();
        }
        public async Task<Order> AddAsync(Order entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<Order> UpdateAsync(Order entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<string> DeleteAsync(Order entity)
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
