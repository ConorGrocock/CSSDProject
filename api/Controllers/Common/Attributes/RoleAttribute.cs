using api.Models.Enums;

namespace api.Controllers.Common.Attributes;

public class RoleAttribute : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
{
    public RoleAttribute(params Role[] roles)
    {
        if (roles.Any())
        {
            Roles = string.Join(",", roles);
        }
    }
}