using Microsoft.Extensions.DependencyInjection;
using Web.Core.Interfaces.Event;
using Web.Events.Events;
using Web.Events.Services;

namespace Web.Events
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEvents(this IServiceCollection services)
        {
            services.AddSingleton<IEventService, EventService>();
            services.AddScoped<IEventHandler<LoginEvent>, LoginEventHandler>();

            return services;
        }
    }
}
