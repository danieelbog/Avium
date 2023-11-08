using Web.Core.DTOs.Response;
using Web.Core.Interfaces.Response;

namespace Web.Services.Services.Response
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

        public ApiResponseDto<T> CreateResponse<T>(T data)
        {
            return new ApiResponseDto<T>
            {
                Data = data
            };
        }
    }
}
