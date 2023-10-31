using Web.Core.DTOs.Response;
using Web.Core.Exceptions;

namespace Web.BFF.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Dictionary<Type, int> _statusCodeMap;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
            _statusCodeMap = new Dictionary<Type,int>
            {
                { typeof(RegistrationFailedException), StatusCodes.Status400BadRequest },
                { typeof(EntityAlreadyExists), StatusCodes.Status400BadRequest },
                { typeof(UnauthorizedAccessException), StatusCodes.Status401Unauthorized },
                { typeof(NotFoundException), StatusCodes.Status404NotFound }
            };
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var exceptionType = ex.GetType();
            if (_statusCodeMap.TryGetValue(exceptionType, out int statusCode))
            {
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsJsonAsync(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new ApiResponse<object> { Success = false, Message = ex.Message });
            }
        }
    }
}
