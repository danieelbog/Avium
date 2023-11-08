namespace Web.Services.Exceptions
{
    public class EntityAlreadyExists : Exception
    {
        public EntityAlreadyExists(string message) : base(message)
        {
        }
    }
}
