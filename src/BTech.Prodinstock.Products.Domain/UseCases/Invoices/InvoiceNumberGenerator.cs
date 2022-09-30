using BTech.Prodinstock.Core;
using BTech.Prodinstock.Products.Domain.Queries;

namespace BTech.Prodinstock.Products.Domain.UseCases.Invoices
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

            return 
                $"{currentYear}" +
                $"-" +
                $"{invoiceCount.Value.ToString().PadLeft(4, '0')}";
        }
    }
}
