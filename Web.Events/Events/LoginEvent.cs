using Web.Core.Interfaces.Event;
using Web.Core.Models.User;

namespace Web.Events.Events
{
    public class LoginEvent : IEvent
    {
        public ApplicationUser ApplicationUser { get; set; }
    }
}
