using FluentValidation;
using hahn.Domain.Entities.BuyerAggregate;
using hahn.Domain.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hahn.Service.Models.BuyerModels;

namespace hahn.Service.Models
{
    public class OrderModels
    {
        public class AddOrder
        {
            public DateTime Created { get; set; }
            public float Price { get; set; }
            public string BuyerId { get; set; }
            public Guid BuyerAddressId { get; set; }
            public List<OrderProducts> Items { get; set; }

            public class AddOrderModelValidator : AbstractValidator<AddOrder>
            {
                public AddOrderModelValidator()
                {
                    RuleFor(x => x.Created)
                       .NotNull().NotEmpty().WithMessage("Please specify a Date.");
                    RuleFor(x => x.Price)
                       .NotNull().NotEmpty().WithMessage("Please specify a Price.");
                    RuleFor(x => x.BuyerId)
                       .NotNull().NotEmpty().WithMessage("Please specify the buyer.");
                    RuleFor(x => x.BuyerAddressId)
                       .NotNull().NotEmpty().WithMessage("Please specify a phone a address.");
                    RuleFor(x => x.Items)
                      .NotNull().NotEmpty().WithMessage("Please specify the products.");

                }
            }

            public static implicit operator Order(AddOrder model)
            {
                IEnumerable<OrderItems> orderItems = model.Items.Select(x => new OrderItems
                {
                    OrderId = x.OrderId,
                    ProductId = x.ProductId,

                });

                return new Order
                {
                    Created = model.Created,
                    Price = model.Price,
                    BuyerId = model.BuyerId,
                    BuyerAddressId = model.BuyerAddressId,
                    Items = new List<OrderItems>(orderItems)

                };
            }
        }
        public class OrderProducts
        {
            public Guid ProductId { get; set; }
            public Guid OrderId { get; set; }
            public class OrderProductModelValidator : AbstractValidator<OrderProducts>
            {
                public OrderProductModelValidator()
                {
                    RuleFor(x => x.ProductId)
                       .NotNull().NotEmpty().WithMessage("Please specify the product.");
                }
            }

            public static implicit operator OrderItems(OrderProducts model)
            {
                return new OrderItems
                {

                    ProductId = model.ProductId,
                    OrderId = model.OrderId,

                };
            }

        }
    }
}
