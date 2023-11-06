using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Web.App.Application.Web.Services.Interfaces.Auth;
using Web.App.Core.Web.Core.DTOs.Account;
using Web.App.Core.Web.Core.DTOs.Auth;
using Web.App.Core.Web.Core.Exceptions;
using Web.App.Core.Web.Core.Models;

namespace Web.App.Application.Web.Services.Impl.Services.Services.Auth
{
    public class AuthService : IAuthService
    {
        #region Private Members
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        #endregion

        #region Constructors
        public AuthService(
            UserManager<ApplicationUser> userManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        #endregion

        #region Private Methods
        private async Task<List<Claim>> GetAuthClaims(ApplicationUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return authClaims;
        }
        #endregion

        #region Implementation of IService

        public async Task<TokenDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
                throw new NotFoundException($"User with provided credentials was not found");

            var authClaims = await GetAuthClaims(user);
            var token = _tokenService.GetJwtSecurityToken(authClaims);
            return new TokenDto()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            };
        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            var userExists = await _userManager.FindByNameAsync(registerDto.Username);
            if (userExists != null)
                throw new EntityAlreadyExists("A user with the provided username already exists.");

            var user = new ApplicationUser
            {
                Email = registerDto.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerDto.Username
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
                throw new RegistrationFailedException("User registration failed. Please try again.");

            return new UserDto(user.Email, user.UserName);
        }

        #endregion
    }
}
