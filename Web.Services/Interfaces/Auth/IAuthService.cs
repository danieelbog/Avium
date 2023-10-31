using Ecom.Core.DTOs.Account;
using System.Security.Claims;
using Web.Core.DTOs.Auth;
using WebApp.BFF.Core.Models;

namespace Web.Services.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<TokenDto> LoginAsync(LoginDto loginDto);
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
    }
}
