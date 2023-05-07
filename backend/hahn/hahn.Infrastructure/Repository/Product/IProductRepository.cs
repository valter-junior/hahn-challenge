using hahn.Domain.Entities;
using hahn.Infrastructure.Repository.Base;
using System.Linq.Expressions;

namespace hahn.Infrastructure.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> AddAsync(Product entity);
        Task<IEnumerable<Product>> GetAllAsync(params Expression<Func<Product, object>>[] includes);
        Task<Product?> GetByIdAsync(Guid? id, params Expression<Func<Product, object>>[] includes);
        Task<Product> UpdateAsync(Product entity);
        Task<Product> DeleteAsync(Product entity);
        Task<bool> GetManagerById(string id);


    }
}
