using api.Models.Entities;

namespace api.Models.Dtos;

public class InvoiceDto
{
    public decimal Amount { get; set; } = default!;
    public string PaymentReference { get; set; } = default!;
    public DateTime IssuedAt { get; set; } = default!;
    public Bill[] Bills { get; set; } = default!;
}