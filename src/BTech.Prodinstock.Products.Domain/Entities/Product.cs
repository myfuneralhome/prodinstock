namespace BTech.Prodinstock.Products.Domain.Entities
{
    public sealed class Product
    {

        public string Id { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public short NumberInStock { get; set; }
        public decimal SalePrice { get; set; }
        public decimal VATRate { get; set; }
        public decimal BuyingPrice { get; set; }
        public string? CategoryId { get; set; }
        public string? SupplierId { get; set; }
        public Category? Category { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
