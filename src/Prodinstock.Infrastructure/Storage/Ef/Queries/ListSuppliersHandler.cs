using Prodinstock.Core;
using Prodinstock.Infrastructure.Storage.Ef;
using Prodinstock.Products.Domain.Entities;
using Prodinstock.Products.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace Prodinstock.Infrastructure.Queries
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
