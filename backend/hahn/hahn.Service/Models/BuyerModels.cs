
using FluentValidation;
using hahn.Domain.Entities.BuyerAggregate;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace hahn.Service.Models
{
    public class BuyerModels
    {
        public class AddBuyer
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Password { get; set; }
            public DateTime Created { get; set; }
            public List<BuyerAddress> BuyerAddresses { get; set; }

            public class AddBuyerModelValidator : AbstractValidator<AddBuyer>
            {
                public AddBuyerModelValidator()
                {
                    RuleFor(x => x.Name)
                       .NotNull().NotEmpty().WithMessage("Please specify a name.");
                    RuleFor(x => x.Email)
                        .EmailAddress().WithMessage("Invalid email address")
                        .NotNull().NotEmpty().WithMessage("Please specify a email.");
                    RuleFor(x => x.Phone)
                       .NotNull().NotEmpty().WithMessage("Please specify a phone number.");
                    RuleFor(x => x.Password)
                       .NotNull().NotEmpty().WithMessage("Please specify a phone a password.");

                }
            }


            public static implicit operator Buyer(AddBuyer model)
            {
                return new Buyer
                {
                    Name = model.Name,
                    Email = model.Email,
                    Phone = model.Phone,
                    Password = model.Password,
                    Created = model.Created,


                };
            }

        }
        public class AddBuyerAddresses
        {
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zipcode { get; set; }
            public string Country { get; set; }
            public class AddBuyerAddressesModelValidator : AbstractValidator<AddBuyerAddresses>
            {
                public AddBuyerAddressesModelValidator()
                {
                    RuleFor(x => x.Street)
                       .NotNull().NotEmpty().WithMessage("Please specify the street.");
                    RuleFor(x => x.City)
                       .NotNull().NotEmpty().WithMessage("Please specify a city.");
                    RuleFor(x => x.State)
                       .NotNull().NotEmpty().WithMessage("Please specify a phone the state.");
                    RuleFor(x => x.Zipcode)
                      .NotNull().NotEmpty().WithMessage("Please specify a phone the ZipCode.");
                    RuleFor(x => x.Country)
                      .NotNull().NotEmpty().WithMessage("Please specify a phone the country.");

                }
            }

            public static implicit operator BuyerAddress(AddBuyerAddresses model)
            {
                return new BuyerAddress
                {
                    Street = model.Street,
                    City = model.City,
                    State = model.State,
                    Zipcode = model.Zipcode,
                    Country = model.Country

                };
            }
        }
    }
}
