using Prodinstock.Core;
using Prodinstock.Infrastructure.Storage.Ef;
using Prodinstock.Products.Domain.Entities;
using Prodinstock.Products.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace Prodinstock.Infrastructure.Queries
{
    internal sealed class ListInvoicesHandler
        : IQueryHandler<ListInvoices, ExistingInvoice[]>
    {
        private readonly ProductContext _productContext;

        public ListInvoicesHandler(
            ProductContext productContext)
        {
            _productContext = productContext;
        }

        async Task<ExistingInvoice[]> IQueryHandler<ListInvoices, ExistingInvoice[]>.HandleAsync(ListInvoices query)
        {
            var suppliers = await _productContext.Set<Invoice>()
                .Select(i => new ExistingInvoice() 
                { 
                    Id = i.Id, 
                    Name = i.Name,
                    Number = i.Number,
                    BuyerFullName = i.BuyerFullName,
                    BuyerPostalAddress = i.BuyerPostalAddress,
                    CreationDate = i.CreationDate,
                    State = i.State
                })
                .ToArrayAsync();


            return suppliers;
        }
    }

}
