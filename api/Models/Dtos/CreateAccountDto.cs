using api.Models.Dtos;

namespace api.Models.Dtos;

public class CreateAccountDto
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public bool ImmediatePayment { get; set; }
    public CreateAddressDto PostalAddress { get; set; } = default!;
}
