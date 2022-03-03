using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace api.Services.Common;

public struct NorTollClaimNames
{
    /// <summary>User Identifier</summary>
    public const string Name = JwtRegisteredClaimNames.Sub;
    public const string Role = "role";
    public const string HumanName = JwtRegisteredClaimNames.Name;
    public const string Email = JwtRegisteredClaimNames.Email;
}