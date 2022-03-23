using api.Models.Common;

namespace api.Models.Dtos;

public class BasicAccountDto : BaseEntityDto
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
}