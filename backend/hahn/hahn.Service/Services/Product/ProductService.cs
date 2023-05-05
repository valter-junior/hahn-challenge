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
                var userManager = await _repository.GetManagerById(model.ManagerId);

                if (!userManager)
                    return ResponseBuilder.NotFoundResponse().WithMessage("User not exist");

                var result = await _repository.AddAsync(model);

                return ResponseBuilder.OkResponse(result);
            }
            catch (Exception e)
            {
                return ResponseBuilder.ErrorResponse().WithMessage(e.Message);
            }
        }

        public async Task<ResponseModel<IEnumerable<Product>>> GetAllAsync()
        {
            try
            {

                var getProducts = await _repository.GetAllAsync();

                return ResponseBuilder.OkResponse(getProducts);
            }
            catch (Exception e)
            {
                return ResponseBuilder.ErrorResponse().WithMessage(e.Message);
            }

        }

        public async Task<ResponseModel<Product>> UpdateAsync(UpdateProduct model)
        {
            try
            {
                var search = _repository.GetByIdAsync(model.Id);

                if (search.Result == null) return ResponseBuilder.ConflictResponse().WithMessage("Product not exists");

                search.Result.Name = model.Name;
                search.Result.Description = model.Description;
                search.Result.Value = model.Value;


                var result = await _repository.UpdateAsync(search.Result);

                return ResponseBuilder.OkResponse(result);
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
                    return ResponseBuilder.NotFoundResponse("Product does not exist.");
                }

            }
            catch (Exception ex)
            {
                return ResponseBuilder.ErrorResponse().WithMessage(ex.Message);
            }
        }

    }
}
