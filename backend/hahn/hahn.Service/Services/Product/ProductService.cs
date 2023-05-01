using hahn.Domain.Entities;
using hahn.Infrastructure.Helpers;
using hahn.Infrastructure.Repositories;
using static hahn.Service.Models.ProductModels;

namespace hahn.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;


        public ProductService(IProductRepository productRepository)
        {
            _repository = productRepository;

        }

        public async Task<ResponseModel<Product>> AddAsync(AddProduct model)
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
