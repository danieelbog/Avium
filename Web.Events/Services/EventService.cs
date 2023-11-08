using Microsoft.Extensions.DependencyInjection;
using Web.Core.Interfaces.Event;

namespace Web.Events.Services
{
    public class EventService : IEventService
    {
        private readonly IServiceProvider _serviceProvider;

        public EventService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Raise<T>(T args) where T : IEvent
        {
            using var scope = _serviceProvider.CreateScope();
            var handlers = scope.ServiceProvider.GetServices<IEventHandler<T>>();
            foreach (var handler in handlers)
            {
                handler.Handle(args);
            }
        }

        public void Raise<T, A>(A args) where T : IEvent
        {
            using var scope = _serviceProvider.CreateScope();
            var handlers = scope.ServiceProvider.GetServices<IEventHandler<T, A>>();
            foreach (var handler in handlers)
            {
                handler.Handle(args);
            }
        }
    }
}
