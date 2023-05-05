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
                var buyer = await _repository.GetBuyerById(model.BuyerId);
                var buyerAddress = await _repository.GetBuyerAddressById(model.BuyerAddressId, model.BuyerId);
                var products = _repository.GetProductsById(model);

                if (!buyer)
                    return ResponseBuilder.ConflictResponse().WithMessage("Buyer not exist.");

                if (!buyerAddress)
                    return ResponseBuilder.ConflictResponse().WithMessage("Buyer not exist or address not match.");

                if (!products)
                    return ResponseBuilder.ConflictResponse().WithMessage("Product or products not exist.");


                var result = await _repository.AddAsync(model);

                return ResponseBuilder.OkResponse(result);
            }
            catch (Exception e)
            {
                return ResponseBuilder.ErrorResponse().WithMessage(e.Message);
            }
        }

        public async Task<ResponseModel<IEnumerable<Order>>> GetAllAsync()
        {
            try
            {

                var getOrders = await _repository.GetAllAsync();

                return ResponseBuilder.OkResponse(getOrders);
            }
            catch (Exception e)
            {
                return ResponseBuilder.ErrorResponse().WithMessage(e.Message);
            }

        }

        public async Task<ResponseModel<string>> DeleteAsync(Guid id)
        {
            try
            {
                var product = await _repository.GetByIdAsync(id);

                if (product != null)
                {

                    await _repository.DeleteAsync(product);

                    return ResponseBuilder.OkResponse("Success");

                }
                else
                {
                    return ResponseBuilder.NotFoundResponse("Order does not exist.");
                }

            }
            catch (Exception ex)
            {
                return ResponseBuilder.ErrorResponse().WithMessage(ex.Message);
            }
        }

    }
}
