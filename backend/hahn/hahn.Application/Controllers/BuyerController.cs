using hahn.Infrastructure.Helpers;
using FluentValidation.Results;
using hahn.Service.Services;
using Microsoft.AspNetCore.Mvc;
using static hahn.Service.Models.BuyerModels;
using static hahn.Service.Models.BuyerModels.AddBuyer;
using static hahn.Service.Models.BuyerModels.UpdateBuyer;

namespace hahn.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class BuyerController : ControllerBase
    {
        private readonly IBuyerService _buyerService;
        public BuyerController(IBuyerService buyerService)
        {
            _buyerService = buyerService;
        }

        [HttpGet]
        [Route("list-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return await _buyerService.GetAllAsync();
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(AddBuyer buyer)
        {
            AddBuyerModelValidator validator = new();
            ValidationResult result = validator.Validate(buyer);

            if (result.IsValid)
                return await _buyerService.AddAsync(buyer);

            return ResponseBuilder.Response(400).WithMessages(result.Errors.Select(x => x.ErrorMessage).ToList());
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(UpdateBuyer buyer)
        {
            UpdateBuyerModelValidator validator = new();
            ValidationResult result = validator.Validate(buyer);

            if (result.IsValid)
                return await _buyerService.UpdateAsync(buyer);

            return ResponseBuilder.Response(400).WithMessages(result.Errors.Select(x => x.ErrorMessage).ToList());
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            return await _buyerService.DeleteAsync(id);
        }
    }
}
