using Web.Core.DTOs.Logging;

namespace Web.Services.Interfaces.Logging
{
    public interface ILoggingService
    {
        public Task LogAsync(LoggingDataDto loggingDataDto);
    }
}
