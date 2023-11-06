namespace Web.App.Persistence.Web.EntityFramework
{
    public interface IApplicationDBContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
