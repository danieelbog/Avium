using Ecom.Services.Exceptions.Error;
using System.Runtime.Serialization;

namespace Ecom.Services.Exceptions.Exception
{
    /// <summary>
    /// A <see cref="ServiceException"/> that is thrown when an entity was not found.
    /// </summary>
    [Serializable]
    public class NotFoundServiceException : ServiceException
    {
        #region Public Constructors

        public NotFoundServiceException()
            : base(new NotFoundServiceError())
        {

        }

        public NotFoundServiceException(NotFoundServiceError error)
            : base(error)
        {
        }

        public NotFoundServiceException(string developerMessage)
            : base(new NotFoundServiceError(developerMessage))
        {
        }

        public NotFoundServiceException(string module, string moduleError)
            : base(new NotFoundServiceError(module, moduleError))
        {
        }

        public NotFoundServiceException(string module, string moduleError, string entity)
            : base(new NotFoundServiceError(module, moduleError, entity))
        {
        }

        public NotFoundServiceException(string module, string moduleError, string entity, string property, string value)
            : base(new NotFoundServiceError(module, moduleError, entity, property, value))
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected NotFoundServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
        #endregion
    }
}