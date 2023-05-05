using hahn.Domain.Entities;
using hahn.Domain.Entities.BuyerAggregate;
using hahn.Domain.Entities.OrderAggregate;
using hahn.Domain.Enums;
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
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Order> AddAsync(Order entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Order>> GetAllAsync(params Expression<Func<Order, object>>[] includes)
        {
            return await _db.Orders.Include(x => x.Items).ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(Guid? id, params Expression<Func<Order, object>>[] includes)
        {

            var search = _db.Orders.Where(x => x.Id == id);

            return await search.FirstOrDefaultAsync();
        }
        public async Task<bool> GetBuyerById(string id)
        {
            return await _db.Buyers.Where(x => x.Id == id && x.UserType == eUserType.Buyer).AnyAsync();
        }

        public async Task<bool> GetBuyerAddressById(Guid id, string buyerId)
        {
            return await _db.BuyerAddresses.Where(x => x.Id == id && x.BuyerId == buyerId).AnyAsync();
        }

        public bool GetProductsById(Order entity)
        {
            var match = entity.Items.All(x => _db.Products.Select(p => p.Id).Contains(x.ProductId));

            return match;
        }

        public async Task<Order> UpdateAsync(Order entity)
        {
            _db.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<string> DeleteAsync(Order entity)
        {

            _db.Remove(entity);
            await _db.SaveChangesAsync();
            return "Success!";

        }
    }
}
