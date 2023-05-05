using hahn.Infrastructure.Helpers;
using hahn.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static hahn.Service.Models.OrderModels;
using FluentValidation.Results;
using static hahn.Service.Models.OrderModels.AddOrder;

namespace hahn.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize("Bearer")]
    public class OrderController: ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(AddOrder order)
        {
            AddOrderModelValidator validator = new();
            ValidationResult result = validator.Validate(order);

            if (result.IsValid)
                return await _orderService.AddAsync(order);

            return ResponseBuilder.Response(400).WithMessages(result.Errors.Select(x => x.ErrorMessage).ToList());
        }

        [HttpGet]
        [Route("list-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return await _orderService.GetAllAsync();
        }


        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            return await _orderService.DeleteAsync(id);
        }
    }
}
