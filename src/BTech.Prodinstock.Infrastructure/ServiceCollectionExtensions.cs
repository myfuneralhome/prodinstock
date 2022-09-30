using BTech.Prodinstock.Core;
using BTech.Prodinstock.Infrastructure.Pdf;
using BTech.Prodinstock.Infrastructure.Queries;
using BTech.Prodinstock.Infrastructure.Storage.Ef;
using BTech.Prodinstock.Infrastructure.Storage.Ef.Queries;
using BTech.Prodinstock.Products.Domain.Queries;
using BTech.Prodinstock.Products.Domain.UseCases.Invoices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BTech.Prodinstock.DependencyInjection
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
            services.TryAddScoped(typeof(IQueryHandler<SearchAccountingAccount, ExistingAccountingAccount[]>), typeof(SearchAccountingAccountHandler));
            services.TryAddScoped(typeof(IQueryHandler<ListInvoices, ExistingInvoice[]>), typeof(ListInvoicesHandler));
            services.TryAddScoped(typeof(IQueryHandler<ListOrderProducts, ExistingOrderProduct[]>), typeof(ListOrderProductsHandler));
            services.TryAddScoped(typeof(IQueryHandler<ValidatedInvoicesInASpecificYearSearch, ValidatedInvoicesInASpecificYearCount>),
                typeof(ValidatedInvoicesInASpecificYearCountHandler));

            return services;
        }

        public static IServiceCollection AddInvoicePdfGeneration(this IServiceCollection services)
        {
            services.TryAddScoped<InvoiceFileGenerator>();
            services.TryAddScoped<IInvoiceFileGeneration, InvoicePdfGeneration>();

            return services;
        }
    }
}
