using api.Models.Common;

namespace api.Models.Entities;

public class Journey : BaseEntity
{
    public decimal Distance { get; set; } = default!;
    
}