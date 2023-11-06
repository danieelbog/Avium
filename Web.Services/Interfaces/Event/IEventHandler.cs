namespace Web.Services.Interfaces.Event
{
    public interface IEventHandler<in T> where T : IEvent
    {
        void Handle(T args);
    }

    public interface IEventHandler<in T, in A> where T : IEvent
    {
        void Handle(A args);
    }
}
