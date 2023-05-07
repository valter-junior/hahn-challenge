using hahn.Domain.Entities;
using hahn.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hahn.Service.Models.ProductModels;

namespace hahn.Service.Services
{
    public interface IProductService
    {
        Task<ResponseModel<Product>> AddAsync(AddProduct model);
        Task<ResponseModel<IEnumerable<Product>>> GetAllAsync();
        Task<ResponseModel<Product>> UpdateAsync(UpdateProduct model);
        Task<ResponseModel<Product>> DeleteAsync(Guid id);
    }
}
