using api.Models.Entities;
using FluentValidation;

namespace api.Services.Common.Validators.Entities;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(x => x.Line1).NotNull().NotEmpty();
        RuleFor(x => x.City).NotNull().NotEmpty();
        RuleFor(x => x.Country).NotNull().NotEmpty();
        RuleFor(x => x.Postcode).NotNull().NotEmpty();
    }
}