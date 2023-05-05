using hahn.Domain.Entities.OrderAggregate;
using hahn.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hahn.Service.Models.OrderModels;

namespace hahn.Service.Services
{
    public interface IOrderService
    {
        Task<ResponseModel<Order>> AddAsync(AddOrder model);
        Task<ResponseModel<IEnumerable<Order>>> GetAllAsync();
        Task<ResponseModel<string>> DeleteAsync(Guid id);
    }
}
