using hahn.Domain.Entities.BuyerAggregate;
using hahn.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
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
        Task<ResponseModel<IEnumerable<Buyer>>> GetAllAsync();
        Task<ResponseModel<IdentityResult>> AddAsync(AddBuyer model);
        Task<ResponseModel<Buyer>> UpdateAsync(UpdateBuyer model);
        Task<ResponseModel<string>> DeleteAsync(string id);
    }
}
