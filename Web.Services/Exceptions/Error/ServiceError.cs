namespace Ecom.Services.Exceptions.Error
{

    /// <summary>
    /// Base class for all Errors. A service error includes a code that is unique among all errors and
    /// a developer message that will help the developer understand what exactly happened.
    /// </summary>
    /// <remarks>
    /// For Each <see cref="ServiceException"/> a ServiceError implementation must be created that 
    /// contains information about the exception that will be shown to the api developer.
    /// </remarks>
    public class ServiceError
    {
        #region Public Properties

        public string Type
        {
            get { return GetType().Name; }
        }

        /// <summary>
        /// The code of the error.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// A message that is used to pass useful information to the developer
        /// </summary>
        /// <remarks>
        /// This message should not be displayed to the end user
        /// </remarks>
        public string DeveloperMessage { get; set; }

        #endregion

        #region Constructors

        public ServiceError()
        {
            Code = StatusCodes.InternalServerError;
            DeveloperMessage = "Internal Server Error";
        }

        public ServiceError(string code, string developerMessage)
        {
            Code = code;
            DeveloperMessage = developerMessage;
        }

        public ServiceError(string statusCode, string module, string moduleError, string developerMessage)
        {
            Code = ConstructCode(statusCode, module, moduleError);
            DeveloperMessage = developerMessage;
        }

        #endregion

        private string ConstructCode(string statusCode, string module, string moduleError)
        {
            return statusCode + (module ?? "000") + (moduleError ?? "000");
        }
    }
}