using Microsoft.EntityFrameworkCore;

namespace Web.EntityFramework.Database
{
    public interface IApplicationDBContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
