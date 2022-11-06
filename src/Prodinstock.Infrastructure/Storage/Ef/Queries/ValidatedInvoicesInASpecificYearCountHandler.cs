using Prodinstock.Core;
using Prodinstock.Products.Domain.Entities;
using Prodinstock.Products.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace Prodinstock.Infrastructure.Storage.Ef.Queries
{
        internal sealed class ValidatedInvoicesInASpecificYearCountHandler
        : IQueryHandler<ValidatedInvoicesInASpecificYearSearch, ValidatedInvoicesInASpecificYearCount>
        {
            private readonly ProductContext _productContext;

            public ValidatedInvoicesInASpecificYearCountHandler(
                ProductContext productContext)
            {
                _productContext = productContext;
            }

            async Task<ValidatedInvoicesInASpecificYearCount> IQueryHandler<ValidatedInvoicesInASpecificYearSearch, ValidatedInvoicesInASpecificYearCount>.HandleAsync(ValidatedInvoicesInASpecificYearSearch query)
            {
                return new(await _productContext.Set<Invoice>()
                    .Include(i => i.InvoiceStateHistories)
                    .Where(i => i.State == Products.Domain.InvoiceState.Validated)
                    .Where(i => i.InvoiceStateHistories
                        .Any(ish => ish.State == Products.Domain.InvoiceState.Validated
                                    && ish.OperationDate.Year == query.Year))
                    .CountAsync());
        }
    }
}
