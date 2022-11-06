using Prodinstock.Core;
using Prodinstock.Products.Domain;
using Prodinstock.Products.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Prodinstock.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountingAccountsController : CommonController
    {
        private readonly IQueryHandler<SearchAccountingAccount, ExistingAccountingAccount[]> _searchAccountingAccount;

        public AccountingAccountsController(
            IQueryHandler<SearchAccountingAccount, ExistingAccountingAccount[]> searchAccountingAccount,
            ICurrentUserProvider currentUserProvider)
            : base(currentUserProvider)
        {
            _searchAccountingAccount = searchAccountingAccount;
        }

        [HttpGet]
        public async Task<ExistingAccountingAccount[]> List(
            [Required][FromQuery] Filter searchAccountingAccount)
        {
            return await _searchAccountingAccount.HandleAsync(
                new SearchAccountingAccount(searchAccountingAccount.ValueResearched));
        }
    }

    public sealed class Filter
    {
        [Required]
        public string ValueResearched { get; set; } = null!;
    }
}
