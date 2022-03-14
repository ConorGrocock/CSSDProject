using api.Models.Common;
using api.Models.Enums;

namespace api.Models.Entities;

public class PaymentConfirmation : BaseEntity
{
    public string Identifier { get; set; } = default!;
    public DateTime PaidAt { get; set; } = default!;
    public PaymentMethod Method { get; set; } = default!;

    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = default!;
}