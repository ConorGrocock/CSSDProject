using api.Models.Common;

namespace api.Models.Entities;

public class Invoice : BaseEntity
{
    public decimal Amount { get; set; } = default!;
    public string PaymentReference { get; set; } = default!;
    public DateTime IssuedAt { get; set; } = default!;

    public int AccountId { get; set; }
    public Account Account { get; set; } = default!;
    public int PostalAddressId { get; set; }
    public Address PostalAddress { get; set; } = default!;

    public Bill[] Bills { get; set; } = default!;
}