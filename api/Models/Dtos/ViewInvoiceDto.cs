using api.Models.Common;

namespace api.Models.Dtos;

public class ViewInvoiceDto : BaseEntityDto
{
    public string PaymentReference { get; set; } = default!;
    public DateTime IssuedAt { get; set; } = default!;
    public decimal Amount { get; set; } = default!;
    public BasicAccountDto Account { get; set; } = default!;
    public ViewBillDto[] Bills { get; set; } = new ViewBillDto[] { };
}
