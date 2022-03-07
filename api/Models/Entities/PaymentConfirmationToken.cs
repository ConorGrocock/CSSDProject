using api.Models.Common;

namespace api.Models.Entities;

public class PaymentConfirmationToken : BaseEntity, IToken
{
    public string Value { get; set; } = default!;
    public DateTime Expires { get; set; }

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = default!;
}