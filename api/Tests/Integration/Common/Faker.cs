using api.Models.Dtos;
using Bogus;

namespace Tests.Integration.Common;

/// <remarks>Only required properties should be faked</remarks>
public static class Faker
{
    private static readonly string? NullString = null;

    static Faker()
    {
        Bogus.Faker.DefaultStrictMode = true;
    }

    public static readonly Faker<CreateAddressDto> CreateAddressDto
        = new Faker<CreateAddressDto>()
            .RuleFor(x => x.Line1, x => x.Address.StreetAddress())
            .RuleFor(x => x.Line2, NullString)
            .RuleFor(x => x.Line3, NullString)
            .RuleFor(x => x.City, x => x.Address.City())
            .RuleFor(x => x.State, NullString)
            .RuleFor(x => x.Country, x => x.Address.Country())
            .RuleFor(x => x.Postcode, x => x.Address.ZipCode());

    public static readonly Faker<CreateAccountDto> CreateAccountDto
        = new Faker<CreateAccountDto>()
            .RuleFor(x => x.Name, x => x.Person.FullName)
            .RuleFor(x => x.Email, x => x.Person.Email)
            .RuleFor(x => x.ImmediatePayment, x => x.Random.Bool())
            .RuleFor(x => x.PostalAddress, () => CreateAddressDto.Generate());
}