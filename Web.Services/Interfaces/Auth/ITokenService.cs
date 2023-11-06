using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Web.Services.Interfaces.Auth
{
    public interface ITokenService
    {
        JwtSecurityToken GetJwtSecurityToken(List<Claim> authClaims);
    }
}
