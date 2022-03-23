using api.Models.Common;

namespace api.Models.Dtos;

public class ViewBillDto : BaseEntityDto
{
    public decimal Amount { get; set; } = default!;
    public DateTime IssuedAt { get; set; } = default!;
}
