using hahn.Domain.Entities;
using hahn.Domain.Entities.BuyerAggregate;
using hahn.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Infrastructure.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllAsync(params Expression<Func<Product, object>>[] includes);
        Task<Product> AddAsync(Product entity);
        Task<Product> UpdateAsync(Product entity);
        Task<string> DeleteAsync(Product entity);
       
    }
}
