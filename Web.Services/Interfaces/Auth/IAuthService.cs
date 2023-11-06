using Web.Core.DTOs.Auth;
using Web.Core.DTOs.User;

namespace Web.Services.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<TokenDto> LoginAsync(LoginDto loginDto);
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
    }
}
