
using FluentValidation;
using hahn.Domain.Entities.BuyerAggregate;
using hahn.Domain.Enums;

namespace hahn.Service.Models
{
    public class BuyerModels
    {
        public class BuyerAddressesModel
        {
            public Guid? Id { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Zipcode { get; set; }
            public string Country { get; set; }
            public class AddBuyerAddressesModelValidator : AbstractValidator<BuyerAddressesModel>
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

            public static implicit operator BuyerAddress(BuyerAddressesModel model)
            {
                return new BuyerAddress
                {
                    Street = model.Street,
                    City = model.City,
                    State = model.State,
                    Zipcode = model.Zipcode,
                    Country = model.Country,

                };
            }
        }
        public class AddBuyer
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Password { get; set; }
            public DateTime Created { get; set; }
            public List<BuyerAddressesModel> BuyerAddresses { get; set; }

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
                IEnumerable<BuyerAddress> address = model.BuyerAddresses.Select(x => new BuyerAddress()
                {
                    Street = x.Street,
                    City = x.City,
                    State = x.State,
                    Zipcode = x.Zipcode,
                    Country = x.Country,

                });

                return new Buyer
                {
                    Name = model.Name,
                    Email = model.Email,
                    PhoneNumber = model.Phone,
                    UserName = model.Email,
                    Password = model.Password,
                    UserType = eUserType.Buyer,
                    Created = model.Created,
                    BuyerAddresses = new List<BuyerAddress>(address)

                };
            }

        }

        public class UpdateBuyer
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }

            public class UpdateBuyerModelValidator : AbstractValidator<UpdateBuyer>
            {
                public UpdateBuyerModelValidator()
                {
                    RuleFor(x => x.Name)
                       .NotNull().NotEmpty().WithMessage("Please specify a name.");

                    RuleFor(x => x.Phone)
                       .NotNull().NotEmpty().WithMessage("Please specify a phone number.");

                }
            }


            public static implicit operator Buyer(UpdateBuyer model)
            {

                return new Buyer
                {
                    Name = model.Name,
                    PhoneNumber = model.Phone,

                };
            }

        }
    }
}
