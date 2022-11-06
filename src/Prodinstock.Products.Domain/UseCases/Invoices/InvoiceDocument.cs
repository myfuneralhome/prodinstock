namespace Prodinstock.Products.Domain.UseCases.Invoices
{
    public sealed class InvoiceDocument
    {
        public string InvoiceNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DueDate { get; set; }

        public Address SellerAddress { get; set; }
        public Address CustomerAddress { get; set; }

        public List<OrderItem> Items { get; } = new List<OrderItem>();
        public string Comments { get; set; }
    }

    public class OrderItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public record Address(
        string CompanyName,
        string Street,
        string City,
        string State,
        string? Email = null,
        string? Phone = null)
    {
    }
}