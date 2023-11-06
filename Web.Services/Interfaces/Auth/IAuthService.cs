using Web.App.Core.Web.Core.DTOs.Account;
using Web.App.Core.Web.Core.DTOs.Auth;

namespace Web.App.Application.Web.Services.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<TokenDto> LoginAsync(LoginDto loginDto);
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
    }
}
