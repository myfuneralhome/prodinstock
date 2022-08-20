using BTech.Prodinstock.Products.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BTech.Prodinstock.Infrastructure.Storage.Ef
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.TryAddScoped(typeof(IWriteRepository<>), typeof(EfRepository<>));
            services.TryAddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));

            return services;
        }
    }
}
