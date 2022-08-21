using BTech.Prodinstock.Core;
using BTech.Prodinstock.Infrastructure.Queries;
using BTech.Prodinstock.Products.Domain.Queries;
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

        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.TryAddScoped<ListProducts>();
            services.TryAddScoped(typeof(IQueryHandler<ListCategoriesWithProductCount, ExistingCategory[]>), typeof(ListCategoriesWithProductCountHandler));
            services.TryAddScoped(typeof(IQueryHandler<ListSuppliers, ExistingSupplier[]>), typeof(ListSuppliersHandler));
            services.TryAddScoped(typeof(IQueryHandler<ListProducts, ExistingProduct[]>), typeof(ListProductsHandler));

            return services;
        }
    }
}
