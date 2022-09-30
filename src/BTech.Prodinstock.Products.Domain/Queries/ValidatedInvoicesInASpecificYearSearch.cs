using BTech.Prodinstock.Core;

namespace BTech.Prodinstock.Products.Domain.Queries
{
    public sealed record ValidatedInvoicesInASpecificYearSearch
        : IQuery<ValidatedInvoicesInASpecificYearCount>
    {
        public int Year;
    }

    public sealed record ValidatedInvoicesInASpecificYearCount
        (int Value)
    { }
}
