using Web.Core.Interfaces.Event;

namespace Web.Events.Events
{
    public class LoginEventHandler : IEventHandler<LoginEvent>
    {
        public LoginEventHandler()
        { }

        public void Handle(LoginEvent args)
        {
            //do something
        }
    }
}
