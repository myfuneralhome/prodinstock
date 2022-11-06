using Prodinstock.Core;

namespace Prodinstock.Products.Domain.Queries
{
    public sealed record ListOrderProducts
        : IQuery<ExistingOrderProduct[]>
    {
        public string InvoiceId { get; set; } = null!;
    }

    public sealed class ExistingOrderProduct
    {
        public string Id { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
