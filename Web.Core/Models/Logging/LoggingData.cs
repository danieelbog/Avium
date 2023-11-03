using Microsoft.Extensions.Logging;

namespace Web.Core.Models.Logging
{
    public class LoggingData : IModel<Guid>
    {
        #region Implementation of IModel
        public Guid Id { get; set; }
        #endregion

        #region Public Properties
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string? Method { get; set; }
        public string? Path { get; set; }
        public LogLevel LogLevel { get; set; }
        public string? Message { get; set; }
        public string? Exception { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        #endregion
    }
}
