using Ecom.Core.DTOs.Account;
using Microsoft.AspNetCore.Mvc;
using Web.Core.DTOs.Auth;
using Web.Core.DTOs.Response;
using Web.Services.Interfaces.Auth;

namespace JWTAuthentication.NET6._0.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IAuthService _authService;

        public AuthenticateController(
            ITokenService tokenService,
            IAuthService authService)
        {
            _tokenService = tokenService;
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            return Ok(new ApiResponse<TokenDto>
            {
                Data = await _authService.LoginAsync(loginDto),
                Success = true
            });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            return Ok(new ApiResponse<UserDto>
            {
                Data = await _authService.RegisterAsync(registerDto),
                Success = true
            });
        }
    }
}