using hahn.Domain.Entities.BuyerAggregate;
using hahn.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hahn.Service.Models.BuyerModels;

namespace hahn.Service.Services
{
    public interface IBuyerService
    {
        Task<ResponseModel<Buyer>> AddAsync(AddBuyer model);
    }
}
