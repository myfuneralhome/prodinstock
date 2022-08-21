using BTech.Prodinstock.Core;
using BTech.Prodinstock.Infrastructure.Storage.Ef;
using BTech.Prodinstock.Products.Domain.Entities;
using BTech.Prodinstock.Products.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace BTech.Prodinstock.Infrastructure.Queries
{
    internal sealed class ListProductsHandler
        : IQueryHandler<ListProducts, ExistingProduct[]>
    {
        private readonly ProductContext _productContext;

        public ListProductsHandler(
            ProductContext productContext)
        {
            _productContext = productContext;
        }

        async Task<ExistingProduct[]> IQueryHandler<ListProducts, ExistingProduct[]>.HandleAsync(ListProducts query)
        {
            var products = await _productContext.Set<Product>()
                .Include(p => p.Supplier)
                .Include(p => p.Category)
                .Select(p => new ExistingProduct
                {
                    Id = p.Id,
                    Name = p.Name,
                    BuyingPrice = p.BuyingPrice,
                    VATRate = p.VATRate,
                    CreationDate = p.CreationDate,
                    Description = p.Description,
                    NumberInStock = p.NumberInStock,
                    SalePrice = p.SalePrice,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name,
                    SupplierId = p.SupplierId,
                    SupplierName = p.Supplier.Name
                })
                .ToArrayAsync();

            return products;
        }
    }

}
