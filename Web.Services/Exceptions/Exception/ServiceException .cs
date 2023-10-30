using Ecom.Services.Exceptions.Error;
using System.Runtime.Serialization;

namespace Ecom.Services.Exceptions.Exception
{
    /// <summary>
    /// A base Exception that is thrown from the Service layer.
    /// A ServiceException has a <see cref="ServiceError"/> that contains information about the exception.
    /// The error is in a different class so that it can be returned back as a response in case of a REST or SOAP api.
    /// </summary>
    [Serializable]
    public class ServiceException : System.Exception
    {
        #region Public Properties

        public ServiceError Error { get; set; }

        #endregion

        #region Constructors

        public ServiceException()
        {
        }

        public ServiceException(ServiceError error)
        {
            Error = error;
        }

        public ServiceException(string message, ServiceError error)
            : base(message)
        {
            Error = error;
        }

        public ServiceException(string message, System.Exception innerException, ServiceError error)
            : base(message, innerException)
        {
            Error = error;
        }

        #endregion

        public T GetError<T>() where T : ServiceError
        {
            return (T)Error;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected ServiceException(SerializationInfo info, StreamingContext context)
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
    }
}