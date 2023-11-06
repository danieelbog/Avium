using Web.Services.Interfaces.Event;

namespace Web.Services.Impl.Services.Auth.Events
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
