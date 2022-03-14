using api.Models.Common;

namespace api.Models.Entities;

public class SignInToken : BaseEntity, IToken
{
    public string Value { get; set; } = default!;
    public DateTime Expires { get; set; }

    public Guid AccountId { get; set; }
    public Account Account { get; set; } = default!;

}