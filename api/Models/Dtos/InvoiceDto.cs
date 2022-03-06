using api.Models.Entities;

namespace api.Models.Dtos;

public class InvoiceDto
{
    public IEnumerable<Invoice> Invoices { get; set; } = default!;
}