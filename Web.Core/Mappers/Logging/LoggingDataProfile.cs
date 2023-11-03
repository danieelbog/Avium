using AutoMapper;
using Web.Core.DTOs.Logging;
using Web.Core.Models.Logging;

namespace Web.Core.Mappers.Logging
{
    public class LoggingDataProfile : Profile
    {
        public LoggingDataProfile()
        {
            CreateMap<LoggingDataDto, LoggingData>();
        }
    }
}
