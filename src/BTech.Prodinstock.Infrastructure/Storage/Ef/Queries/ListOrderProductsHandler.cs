using BTech.Prodinstock.Core;
using BTech.Prodinstock.Infrastructure.Storage.Ef;
using BTech.Prodinstock.Products.Domain.Entities;
using BTech.Prodinstock.Products.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace BTech.Prodinstock.Infrastructure.Queries
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
