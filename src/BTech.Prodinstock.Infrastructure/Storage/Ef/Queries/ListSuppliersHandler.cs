using BTech.Prodinstock.Core;
using BTech.Prodinstock.Infrastructure.Storage.Ef;
using BTech.Prodinstock.Products.Domain.Entities;
using BTech.Prodinstock.Products.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace BTech.Prodinstock.Infrastructure.Queries
{
    internal sealed class ListSuppliersHandler
        : IQueryHandler<ListSuppliers, ExistingSupplier[]>
    {
        private readonly ProductContext _productContext;

        public ListSuppliersHandler(
            ProductContext productContext)
        {
            _productContext = productContext;
        }

        async Task<ExistingSupplier[]> IQueryHandler<ListSuppliers, ExistingSupplier[]>.HandleAsync(ListSuppliers query)
        {
            var suppliers = await _productContext.Set<Supplier>()
                .Select(c => new ExistingSupplier() { Id = c.Id, Name = c.Name })
                .ToArrayAsync();


            return suppliers;
        }
    }

}
