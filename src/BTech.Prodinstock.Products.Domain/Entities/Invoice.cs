namespace BTech.Prodinstock.Products.Domain.Entities
{
    public sealed class Invoice
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Number { get; set; }
        public DateTime CreationDate { get; set; }
        public InvoiceState State { get; set; }
        public string? BuyerFullName { get; set; }
        public PostalAddress? BuyerPostalAddress { get; set; }

        public ICollection<InvoiceStateHistory> InvoiceStateHistories { get; set; } = null!;

        public ICollection<OrderProduct> OrderProducts { get; set; } = null!;
    }
}