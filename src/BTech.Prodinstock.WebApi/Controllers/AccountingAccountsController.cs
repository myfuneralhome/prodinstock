using BTech.Prodinstock.Core;
using BTech.Prodinstock.Products.Domain.Queries;
using BTech.Prodinstock.Products.Domain.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BTech.Prodinstock.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountingAccountsController : ControllerBase
    {
        private readonly IQueryHandler<SearchAccountingAccount, ExistingAccountingAccount[]> _searchAccountingAccount;

        public AccountingAccountsController(
            IQueryHandler<SearchAccountingAccount, ExistingAccountingAccount[]> searchAccountingAccount)
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