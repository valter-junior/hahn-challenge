using hahn.Domain.Entities;
using System.Linq.Expressions;

namespace hahn.Infrastructure.Repository.User
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetByEmail(string email, params Expression<Func<ApplicationUser, object>>[] includes);
    }
}
