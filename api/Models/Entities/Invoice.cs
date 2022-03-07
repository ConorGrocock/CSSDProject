using api.Models.Common;

namespace api.Models.Entities;

public class Invoice : BaseEntity
{
    public string PaymentReference { get; set; } = default!;
    public DateTime IssuedAt { get; set; } = default!;
    public decimal Amount => Bills.Sum(x => x.Amount);

    public int AccountId { get; set; }
    public Account Account { get; set; } = default!;
    public int PostalAddressId { get; set; }
    public Address PostalAddress { get; set; } = default!;
    public int? PaymentConfirmationId { get; set; }
    public PaymentConfirmation? PaymentConfirmation { get; set; } = default!;

    public List<Bill> Bills { get; } = new List<Bill>();
}