namespace Ecom.Services.Exceptions.Error
{
    /// <summary>
    /// <see cref="ServiceError"/> for the <see cref="NotFoundServiceException"/>.
    /// It contains the name of entity that wasn't found, the name of the property that used to find the entity and the value
    /// </summary>
    public class NotFoundServiceError : ServiceError
    {
        #region Public Properties

        /// <summary>
        /// The name of the Entity that wasn't found
        /// </summary>
        public string Entity { get; set; }

        /// <summary>
        /// The property that used to find the <see cref="Entity"/>
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// The value used to match the <see cref="Property"/>
        /// </summary>
        public string Value { get; set; }

        #endregion

        #region Constructors

        public NotFoundServiceError()
            : base(StatusCodes.NotFound, null, null, "No such entity")
        {
        }

        public NotFoundServiceError(string module, string moduleError)
            : base(StatusCodes.NotFound, module, moduleError, "No such entity")
        {
        }

        public NotFoundServiceError(string module, string moduleError, string entity)
            : base(StatusCodes.NotFound, module, moduleError, entity + " was not found")
        {
            Entity = entity;
        }

        public NotFoundServiceError(string module, string moduleError, string entity, string property, string value)
            : base(StatusCodes.NotFound, module, moduleError, entity + " with " + property + " \'" + value + "\' was not found!")
        {
            Entity = entity;
            Property = property;
            Value = value;
        }

        public NotFoundServiceError(string developerMessage)
            : base(StatusCodes.NotFound, developerMessage)
        {
        }

        #endregion
    }
}