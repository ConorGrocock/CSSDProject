using api.Models.Common;

namespace api.Models.Entities;

public class Account : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public bool ImmediatePayment { get; set; } = default!;

    public int PostalAddressId { get; set; }
    public Address PostalAddress { get; set; } = default!;
}