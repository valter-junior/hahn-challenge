using hahn.Domain.Entities.BuyerAggregate;
using hahn.Domain.Entities.OrderAggregate;
using hahn.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Infrastructure.Repositories
{
    public interface IOrderRepository: IRepository<Order>
    {
        Task<IEnumerable<Order>> GetAllAsync(params Expression<Func<Order, object>>[] includes);
        Task<Order> AddAsync(Order entity);
        Task<Order> UpdateAsync(Order entity);
        Task<string> DeleteAsync(Order entity);
    }
}
