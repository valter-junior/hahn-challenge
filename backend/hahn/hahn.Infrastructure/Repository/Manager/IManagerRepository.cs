using hahn.Domain.Entities;
using hahn.Domain.Entities.BuyerAggregate;
using hahn.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Infrastructure.Repositories
{
    public interface IManagerRepository: IRepository<Manager>
    {
        Task<Buyer> AddAsync(Buyer entity);
    }
}
