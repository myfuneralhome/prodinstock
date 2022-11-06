using Prodinstock.Core;
using Prodinstock.Products.Domain.Queries;

namespace Prodinstock.Products.Domain.UseCases.Invoices
{
    sealed public class InvoiceNumberGenerator
    {
        private readonly IQueryHandler<ValidatedInvoicesInASpecificYearSearch, ValidatedInvoicesInASpecificYearCount> _query;

        public InvoiceNumberGenerator(IQueryHandler<ValidatedInvoicesInASpecificYearSearch, ValidatedInvoicesInASpecificYearCount> query)
        {
            _query = query;
        }

        public async Task<string> ExecuteAsync()
        {
            int currentYear = DateTime.Now.Year;

            var invoiceCount = await _query.HandleAsync(new ValidatedInvoicesInASpecificYearSearch() { Year = currentYear });
            var newInvoiceNumber = invoiceCount.Value + 1;

            return 
                $"{currentYear}" +
                $"-" +
                $"{newInvoiceNumber.ToString().PadLeft(4, '0')}";
        }
    }
}
