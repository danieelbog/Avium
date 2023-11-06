using Microsoft.Extensions.DependencyInjection;
using Web.App.Application.Web.Services.Impl.Services.Services.Auth;
using Web.App.Application.Web.Services.Impl.Services.Services.Response;
using Web.App.Application.Web.Services.Interfaces.Auth;
using Web.App.Application.Web.Services.Interfaces.Response;
using Web.App.Persistence.Web.EntityFramework;

namespace Web.App.Application.Web.Services.Impl
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
