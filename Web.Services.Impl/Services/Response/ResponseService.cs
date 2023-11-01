using Web.Core.DTOs.Response;
using Web.Services.Interfaces.Response;

namespace Web.Services.Impl.Services.Response
{
    public class ResponseService : IResponseService
    {
        #region Private Members

        #endregion

        #region Constructors
        public ResponseService()
        {

        }
        #endregion

        #region Private Methods
        #endregion

        #region Implementation of IService

        #endregion

        public ApiResponse<T> CreateResponse<T>(T data)
        {
            return new ApiResponse<T>
            {
                Data = data
            };
        }
    }
}
