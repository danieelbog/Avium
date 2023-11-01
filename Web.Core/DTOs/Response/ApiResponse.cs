using Web.Core.Exceptions;

namespace Web.Core.DTOs.Response
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
    }
}
