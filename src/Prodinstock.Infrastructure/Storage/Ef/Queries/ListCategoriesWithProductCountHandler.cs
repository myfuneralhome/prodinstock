using Prodinstock.Core;
using Prodinstock.Infrastructure.Storage.Ef;
using Prodinstock.Products.Domain.Entities;
using Prodinstock.Products.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace Prodinstock.Infrastructure.Queries
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
            var categories = await _productContext.Set<Category>()
                .Select(c => new ExistingCategory() { Id = c.Id, Name = c.Name, NumberOfProducts = c.Products.Count })
                .ToListAsync();

            int productWithoutCategoryCount = await _productContext.Set<Product>()
                .Where(p => p.CategoryId == null)
                .CountAsync();

            categories.Add(new ExistingCategory() { Id = null, Name = "", NumberOfProducts = productWithoutCategoryCount });

            return categories.ToArray();
        }
    }

}
