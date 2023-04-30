using hahn.Domain.Entities.BuyerAggregate;
using hahn.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Infrastructure.Repositories
{
    public interface IBuyerRepository : IRepository<Buyer>
    {
        Task<IEnumerable<Buyer>> GetAllAsync(params Expression<Func<Buyer, object>>[] includes);
        Task<Buyer> AddAsync(Buyer entity);
        Task<Buyer> UpdateAsync(Buyer entity);
        Task<string> DeleteAsync(Buyer entity);
    }
}
