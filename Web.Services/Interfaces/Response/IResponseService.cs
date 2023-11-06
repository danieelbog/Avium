using Web.App.Core.Web.Core.DTOs.Response;

namespace Web.App.Application.Web.Services.Interfaces.Response
{
    public interface IResponseService
    {
        public ApiResponse<T> CreateResponse<T>(T data);
    }
}
