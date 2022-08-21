using BTech.Prodinstock.Infrastructure.Storage.Ef;
using BTech.Prodinstock.Products.Domain.Entities;
using BTech.Prodinstock.Products.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace BTech.Prodinstock.Infrastructure.Queries
{
    internal sealed class ListCategoriesWithProductCountHandler
        : IQueryHandler<ListCategoriesWithProductCount, ExistingCategory[]>
    {
        private readonly ProductContext _productContext;

        public ListCategoriesWithProductCountHandler(
            ProductContext productContext)
        {
            _productContext = productContext;
        }

        async Task<ExistingCategory[]> IQueryHandler<ListCategoriesWithProductCount, ExistingCategory[]>.HandleAsync(ListCategoriesWithProductCount query)
        {
            var categories = await _productContext.Set<Product>()
                .GroupBy(p => p.CategoryId)
                .Select(groupByCategory => new ExistingCategory { Id = groupByCategory.Key, NumberOfProducts = groupByCategory.Count() })
                .ToArrayAsync();

            return categories;
        }
    }

}
