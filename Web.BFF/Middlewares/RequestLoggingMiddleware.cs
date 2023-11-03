﻿using Web.Core.DTOs.Logging;
using Web.Services.Interfaces.Logging;

namespace YourNamespace.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public RequestLoggingMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;
        }

        public async Task Invoke(HttpContext context)
        {
            await LogRequest(context);
            await _next(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            var loggingData = new LoggingDataDto
            {
                Method = context.Request.Method,
                Path = context.Request.Path,
                LogLevel = LogLevel.Error,
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
                var loggingService = scope.ServiceProvider.GetRequiredService<ILoggingService>();
                await loggingService.LogAsync(loggingData);
            }
        }
    }
}