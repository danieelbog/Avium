using Web.Core.DTOs.Response;

namespace Web.Core.Interfaces.Response
{
    public interface IResponseService
    {
        public ApiResponseDto<T> CreateResponse<T>(T data);
    }
}
