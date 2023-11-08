using Microsoft.Extensions.DependencyInjection;

namespace Web.Map
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            #region Map
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion

            return services;
        }
    }
}
