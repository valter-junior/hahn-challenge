using FluentValidation;
using hahn.Domain.Entities;
using hahn.Domain.Entities.BuyerAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hahn.Service.Models.BuyerModels;

namespace hahn.Service.Models
{
    public class ProductModels
    {
        public class AddProduct
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public float Value { get; set; }
            public string ManagerId { get; set; }

            public class AddProductModelValidator : AbstractValidator<AddProduct>
            {
                public AddProductModelValidator()
                {
                    RuleFor(x => x.Name)
                       .NotNull().NotEmpty().WithMessage("Please specify a name.");
                    RuleFor(x => x.Description)
                       .NotNull().NotEmpty().WithMessage("Please specify a description.");
                    RuleFor(x => x.Value)
                       .NotNull().NotEmpty().WithMessage("Please specify a phone a password.");
                    RuleFor(x => x.ManagerId)
                       .NotNull().NotEmpty().WithMessage("Please specify a manager user.");

                }
            }

            public static implicit operator Product(AddProduct model)
            {
                return new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Value = model.Value,
                    ManagerId = model.ManagerId

                };
            }
        }

        public class UpdateProduct
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public float Value { get; set; }

            public class UpdateProductModelValidator : AbstractValidator<UpdateProduct>
            {
                public UpdateProductModelValidator()
                {
                    RuleFor(x => x.Id)
                       .NotNull().NotEmpty().WithMessage("Please specify the product id.");
                    RuleFor(x => x.Name)
                       .NotNull().NotEmpty().WithMessage("Please specify a name.");
                    RuleFor(x => x.Description)
                       .NotNull().NotEmpty().WithMessage("Please specify a description.");
                    RuleFor(x => x.Value)
                       .NotNull().NotEmpty().WithMessage("Please specify a phone a password.");

                }
            }

            public static implicit operator Product(UpdateProduct model)
            {
                return new Product
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Value = model.Value,
                };
            }
        }
    }
}
