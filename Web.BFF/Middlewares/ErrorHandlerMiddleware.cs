using Web.Core.DTOs.Logging;
using Web.Core.DTOs.Response;
using Web.Core.Exceptions;

namespace Web.BFF.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Dictionary<Type, int> _statusCodeMap;
        private readonly IServiceProvider _serviceProvider;

        public ErrorHandlerMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _statusCodeMap = new Dictionary<Type, int>
            {
                { typeof(RegistrationFailedException), StatusCodes.Status400BadRequest },
                { typeof(EntityAlreadyExists), StatusCodes.Status400BadRequest },
                { typeof(UnauthorizedAccessException), StatusCodes.Status401Unauthorized },
                { typeof(NotFoundException), StatusCodes.Status404NotFound }
            };

            _serviceProvider = serviceProvider;
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
            var statusCode = _statusCodeMap.TryGetValue(exceptionType, out int code) ? code : StatusCodes.Status500InternalServerError;
            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsJsonAsync(new ApiResponseDto<ExceptionDto>
            {
                Data = new ExceptionDto(exceptionType.Name, ex.Message)
            });

            LogExceptionAsync(context, ex);
        }

        private void LogExceptionAsync(HttpContext context, Exception ex)
        {
            var loggingData = new LoggingDataDto
            {
                Id = Guid.NewGuid(),
                Method = context.Request.Method,
                Path = context.Request.Path,
                LogLevel = LogLevel.Error,
                Message = ex.Message,
                Exception = ex.GetType().ToString(),
                CreatedAt = DateTimeOffset.UtcNow,
            };

            var routeData = context.GetRouteData();
            if (routeData != null)
            {
                loggingData.ControllerName = routeData.Values.TryGetValue("controller", out var controller)
                    ? controller?.ToString()
                    : "Unknown";

                loggingData.ActionName = routeData.Values.TryGetValue("action", out var action)
                    ? action?.ToString()
                    : "Unknown";
            }

            using (var scope = _serviceProvider.CreateScope())
            {
                var loggingService = scope.ServiceProvider.GetRequiredService<Serilog.ILogger>();
                loggingService.Error("Error occured:{@loggingData}", loggingData);
            }
        }
    }
}
