using api.Models.Common;
using api.Models.Enums;

namespace api.Models.Entities;

public class Account : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public bool ImmediatePayment { get; set; } = default!;
    public Role Role { get; set; } = Role.Driver;

    public int PostalAddressId { get; set; }
    public Address PostalAddress { get; set; } = default!;
}