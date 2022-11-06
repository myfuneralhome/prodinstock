using Prodinstock.Core;
using Prodinstock.Infrastructure.Storage.Ef;
using Prodinstock.Products.Domain.Entities;
using Prodinstock.Products.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace Prodinstock.Infrastructure.Queries
{
    internal sealed class SearchAccountingAccountHandler
        : IQueryHandler<SearchAccountingAccount, ExistingAccountingAccount[]>
    {
        private readonly ProductContext _productContext;

        public SearchAccountingAccountHandler(
            ProductContext productContext)
        {
            _productContext = productContext;
        }

        async Task<ExistingAccountingAccount[]> IQueryHandler<SearchAccountingAccount, ExistingAccountingAccount[]>.HandleAsync(SearchAccountingAccount searchAccountingAccount)
        {
            var query = _productContext.Set<AccountingAccount>().AsQueryable();

            if (int.TryParse(searchAccountingAccount.ValueSearch, out int parsedValue))
            {
                query = query.Where(aa => aa.Number == parsedValue);
            }
            else
            {
                query = query.Where(aa => aa.Description == searchAccountingAccount.ValueSearch);
            }

            return await query
                .Select(aa => new ExistingAccountingAccount()
                {
                    Id = aa.Id,
                    Description = aa.Description,
                    Number = aa.Number
                })
                .ToArrayAsync();
        }
    }
}