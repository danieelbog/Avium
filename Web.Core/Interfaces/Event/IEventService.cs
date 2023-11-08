namespace Web.Core.Interfaces.Event
{
    public interface IEventService
    {
        void Raise<T>(T args) where T : IEvent;

        void Raise<T, A>(A args) where T : IEvent;
    }
}
