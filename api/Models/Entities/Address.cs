using api.Models.Common;

namespace api.Models.Entities;

public class Address : BaseEntity
{
    public string Line1 { get; set; } = default!;
    public string? Line2 { get; set; } = default!;
    public string? Line3 { get; set; } = default!;
    public string City { get; set; } = default!;
    public string? State { get; set; } = default!;
    public string Country { get; set; } = default!;
    public string Postcode { get; set; } = default!;
}
