using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Web.Core.DTOs.Auth;
using Web.Core.DTOs.User;
using Web.Core.Exceptions;
using Web.Core.Models.User;
using Web.Services.Impl.Services.Auth.Events;
using Web.Services.Interfaces.Auth;
using Web.Services.Interfaces.Event;

namespace Web.Services.Impl.Services.Auth
{
    public class AuthService : IAuthService
    {
        #region Private Members
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IEventService _eventService;
        #endregion

        #region Constructors
        public AuthService(
            UserManager<ApplicationUser> userManager,
            ITokenService tokenService,
            IEventService eventService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _eventService = eventService;
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

            _eventService.Raise(new LoginEvent { ApplicationUser = user });

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

            return new UserDto(user.UserName, user.Email);
        }

        #endregion
    }
}
