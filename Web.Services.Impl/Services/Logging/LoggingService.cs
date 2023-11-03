using AutoMapper;
using Web.Core.DTOs.Logging;
using Web.Core.Models.Logging;
using Web.EntityFramework.Database;
using Web.Services.Interfaces.Logging;

namespace Web.Services.Impl.Services.Logging
{
    public class LoggingService : ILoggingService
    {
        #region Private Members
        private readonly IApplicationDBContext _dbContext;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public LoggingService(IApplicationDBContext dbContext,
                              IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        #endregion

        #region Private Methods
        #endregion

        #region Implementation of IService
        public async Task LogAsync(LoggingDataDto loggingDataDto)
        {
            _dbContext.loggingData.Add(_mapper.Map<LoggingData>(loggingDataDto));
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
