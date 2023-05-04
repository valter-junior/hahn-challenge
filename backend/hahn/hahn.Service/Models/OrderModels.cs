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
            public List<OrderProducts> Products { get; set; }

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
                    RuleFor(x => x.Products)
                      .NotNull().NotEmpty().WithMessage("Please specify a phone a product.");

                }
            }

            public static implicit operator Order(AddOrder model)
            {
                return new Order
                {
                    Created = model.Created,
                    Price = model.Price,
                    BuyerId = model.BuyerId,
                    BuyerAddressId = model.BuyerAddressId,

                };
            }
        }
        public class OrderProducts
        {
            public Guid Id { get; set; }
            public class AddBuyerAddressesModelValidator : AbstractValidator<OrderProducts>
            {
                public AddBuyerAddressesModelValidator()
                {
                    RuleFor(x => x.Id)
                       .NotNull().NotEmpty().WithMessage("Please specify the product.");


                }
            }

        }
    }
}
