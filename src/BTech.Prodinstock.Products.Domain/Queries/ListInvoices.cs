using BTech.Prodinstock.Core;

namespace BTech.Prodinstock.Products.Domain.Queries
{
    public sealed record ListInvoices
        : IQuery<ExistingInvoice[]>
    {
    }

    public sealed class ExistingInvoice
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Number { get; set; }
        public DateTime CreationDate { get; set; }
        public InvoiceState State { get; set; }
        public string? BuyerFullName { get; set; }
        public PostalAddress? BuyerPostalAddress { get; set; }
    }
}
