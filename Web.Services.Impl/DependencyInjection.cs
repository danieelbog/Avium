using Microsoft.Extensions.DependencyInjection;
using Web.EntityFramework.Database;
using Web.Services.Impl.Services.Auth;
using Web.Services.Impl.Services.Auth.Events;
using Web.Services.Impl.Services.Event;
using Web.Services.Impl.Services.Response;
using Web.Services.Interfaces.Auth;
using Web.Services.Interfaces.Event;
using Web.Services.Interfaces.Response;

namespace Web.Services.Impl
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            #region Services
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IResponseService, ResponseService>();
            #endregion

            #region Events
            services.AddSingleton<IEventService, EventService>();
            services.AddScoped<IEventHandler<LoginEvent>, LoginEventHandler>();
            #endregion


            return services;
        }
    }
}
