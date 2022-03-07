using api.Models.Common;

namespace api.Models.Entities;

public class Bill : BaseEntity
{
    public decimal Amount { get; set; } = default!;
    public DateTime IssuedAt { get; set; } = default!;

    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; } = default!;
    public int JourneyId { get; set; }
    public Journey Journey { get; set; } = default!;
}