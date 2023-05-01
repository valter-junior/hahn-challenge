using hahn.Domain.Entities.OrderAggregate;
using hahn.Infrastructure.Helpers;
using hahn.Infrastructure.Repositories;
using static hahn.Service.Models.OrderModels;

namespace hahn.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;


        public OrderService(IOrderRepository orderRepository)
        {
            _repository = orderRepository;

        }

        public async Task<ResponseModel<Order>> AddAsync(AddOrder model)
        {
            try
            {
                var result = await _repository.AddAsync(model);

                return ResponseBuilder.OkResponse(result);
            }
            catch (Exception e)
            {
                return ResponseBuilder.ErrorResponse().WithMessage(e.Message);
            }
        }

    }
}
