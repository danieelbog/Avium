using Microsoft.Extensions.DependencyInjection;
using Web.Core.Interfaces.Auth;
using Web.Core.Interfaces.Response;
using Web.Services.Services.Auth;
using Web.Services.Services.Response;

namespace Web.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IResponseService, ResponseService>();

            return services;
        }
    }
}
