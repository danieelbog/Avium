using Web.Core.DTOs.Response;

namespace Web.Services.Interfaces.Response
{
    public interface IResponseService
    {
        public ApiResponse<T> CreateResponse<T>(T data);
    }
}
