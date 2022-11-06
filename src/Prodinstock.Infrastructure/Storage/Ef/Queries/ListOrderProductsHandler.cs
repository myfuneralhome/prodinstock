using Prodinstock.Core;
using Prodinstock.Infrastructure.Storage.Ef;
using Prodinstock.Products.Domain.Entities;
using Prodinstock.Products.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace Prodinstock.Infrastructure.Queries
{
    internal sealed class ListOrderProductsHandler
        : IQueryHandler<ListOrderProducts, ExistingOrderProduct[]>
    {
        private readonly ProductContext _productContext;

        public ListOrderProductsHandler(
            ProductContext productContext)
        {
            _productContext = productContext;
        }

        async Task<ExistingOrderProduct[]> IQueryHandler<ListOrderProducts, ExistingOrderProduct[]>.HandleAsync(ListOrderProducts query)
        {
            var products = await _productContext.Set<OrderProduct>()
                .Select(p => new ExistingOrderProduct
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Quantity = p.Quantity,
                })
                .ToArrayAsync();

            return products;
        }
    }

}
