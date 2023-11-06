using Web.App.Application.Web.Services.Interfaces.Response;
using Web.App.Core.Web.Core.DTOs.Response;

namespace Web.App.Application.Web.Services.Impl.Services.Services.Response
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
