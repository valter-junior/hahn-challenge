using hahn.Domain.Entities;
using hahn.Domain.Entities.BuyerAggregate;
using hahn.Infrastructure.Repository.Base;
using Microsoft.AspNetCore.Identity;
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
        Task<Buyer?> GetByIdAsync(string? id, params Expression<Func<Buyer, object>>[] includes);
        Task<bool> VerifyIfEmailIsUnique(string email);
        Task<IdentityResult> AddBuyerAsync(Buyer buyer, string password);
        Task<Buyer> UpdateAsync(Buyer entity);
        Task<Buyer> DeleteAsync(Buyer entity);
    }
}
