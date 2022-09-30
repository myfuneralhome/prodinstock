namespace BTech.Prodinstock.Products.Domain.Entities
{
    public sealed class OrderProduct
    {
        public string Id { get; set; } = null!;
        public string InvoiceId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
