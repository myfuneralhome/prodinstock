using BTech.Prodinstock.Core;
using BTech.Prodinstock.Infrastructure.Storage.Ef;
using BTech.Prodinstock.Products.Domain.Entities;
using BTech.Prodinstock.Products.Domain.Queries;
using Microsoft.EntityFrameworkCore;

namespace BTech.Prodinstock.Infrastructure.Queries
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