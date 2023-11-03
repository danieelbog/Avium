using Microsoft.EntityFrameworkCore;
using Web.Core.Models.Logging;

namespace Web.EntityFramework.Database
{
    public interface IApplicationDBContext
    {
        DbSet<LoggingData> loggingData { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
