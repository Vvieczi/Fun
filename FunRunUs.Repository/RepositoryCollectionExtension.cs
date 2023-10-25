using Microsoft.Extensions.DependencyInjection;

namespace FunRunUs.Repository
{
    public static class RepositoryCollectionExtensions
    {
        public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IRepository, DefaultRepository>();
            return services;
        }
    }

}