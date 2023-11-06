using Microsoft.Extensions.Logging;

namespace Web.App.Core.Web.Core.DTOs.Logging
{
    public class LoggingDataDto
    {
        public Guid Id { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string? Method { get; set; }
        public string? Path { get; set; }
        public LogLevel LogLevel { get; set; }
        public string? Message { get; set; }
        public string? Exception { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
