using hahn.Infrastructure.Helpers;
using FluentValidation.Results;
using hahn.Service.Services;
using Microsoft.AspNetCore.Mvc;
using static hahn.Service.Models.ProductModels;
using static hahn.Service.Models.ProductModels.AddProduct;
using static hahn.Service.Models.ProductModels.UpdateProduct;
using Microsoft.AspNetCore.Authorization;

namespace hahn.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize("Bearer")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(AddProduct product)
        {
            AddProductModelValidator validator = new();
            ValidationResult result = validator.Validate(product);

            if (result.IsValid)
                return await _productService.AddAsync(product);

            return ResponseBuilder.Response(400).WithMessages(result.Errors.Select(x => x.ErrorMessage).ToList());
        }

        [HttpGet]
        [Route("list-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return await _productService.GetAllAsync();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(UpdateProduct product)
        {
            UpdateProductModelValidator validator = new();
            ValidationResult result = validator.Validate(product);

            if (result.IsValid)
                return await _productService.UpdateAsync(product);

            return ResponseBuilder.Response(400).WithMessages(result.Errors.Select(x => x.ErrorMessage).ToList());
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            return await _productService.DeleteAsync(id);
        }


    }
}
