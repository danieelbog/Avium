namespace Web.Services.Impl.Exceptions
{
    public class EntityAlreadyExists : Exception
    {
        public EntityAlreadyExists(string message) : base(message)
        {
        }
    }
}
