namespace api.Models.Dtos
{
    public partial class CreateAddressDto
    {
        public string Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        public string City { get; set; }
        public string? State { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
    }
}