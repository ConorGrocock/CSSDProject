using api.Models.Dtos;

namespace api.Models.Dtos
{
    public partial class CreateAccountDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool ImmediatePayment { get; set; }
        public CreateAddressDto PostalAddress { get; set; }
    }
}