using Microsoft.Extensions.DependencyInjection;
using Web.EntityFramework.Database;
using Web.Services.Impl.Services.Auth;
using Web.Services.Impl.Services.Response;
using Web.Services.Interfaces.Auth;
using Web.Services.Interfaces.Response;

namespace Web.Services.Impl
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IResponseService, ResponseService>();
            services.AddScoped<IApplicationDBContext, ApplicationDbContext>();

            return services;
        }
    }
}
