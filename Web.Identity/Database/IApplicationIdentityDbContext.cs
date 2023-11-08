namespace Web.IdentityFramework.Database
{
    public interface IApplicationIdentityDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
