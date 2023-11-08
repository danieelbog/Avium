namespace Web.Core.Interfaces.Identity
{
    public interface IApplicationIdentityDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
