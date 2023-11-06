using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Web.App.Application.Web.Services.Interfaces.Auth;

namespace Web.App.Application.Web.Services.Impl.Services.Services.Auth
{
    public class TokenService : ITokenService
    {
        #region Private Members
        private readonly IConfiguration _configuration;

        #endregion

        #region Constructors
        public TokenService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        #endregion

        #region Private Methods
        #endregion

        #region Implementation of IService
        public JwtSecurityToken GetJwtSecurityToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
        #endregion
    }
}
