using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CrunchiVote.Identity.ExtensionMethods;

internal static class JwtClaimsPrincipal
{
    internal static ClaimsPrincipal GetClaimsPrincipal(this JwtSecurityToken jwtSecurityToken)
    {
        ArgumentNullException.ThrowIfNull(jwtSecurityToken);

        var claims = jwtSecurityToken.Claims;
        var identity = new ClaimsIdentity(claims, "jwt", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        return new ClaimsPrincipal(identity);
    }
}