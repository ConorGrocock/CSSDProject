using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace api.Models.Options;

public class AuthenticationOptions
{
    public TimeSpan SignInTokenExpiry { get; set; }
    public string SignInUrlFormat { get; set; } = default!;

    public string JwtIssuer { get; set; } = default!;
    public string JwtAudience { get; set; } = default!;
    public TimeSpan JwtExpiry { get; set; }
    public string JwtSecret { get; set; } = default!;
    public SecurityKey JwtSecretKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSecret));
}