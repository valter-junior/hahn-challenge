using hahn.Domain.Entities;
using hahn.Domain.Entities.BuyerAggregate;
using hahn.Infrastructure.Repository.Base;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace hahn.Infrastructure.Repositories
{
    public interface IManagerRepository
    {
        Task<IdentityResult> AddManagerAsync(Manager manager, string password);
        Task<bool> VerifyIfEmailIsUnique(string email);

    }
}
