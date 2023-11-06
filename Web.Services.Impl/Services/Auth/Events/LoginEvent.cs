using Web.Core.Models.User;
using Web.Services.Interfaces.Event;

namespace Web.Services.Impl.Services.Auth.Events
{
    public class LoginEvent : IEvent
    {
        public ApplicationUser ApplicationUser { get; set; }
    }
}
