namespace Prodinstock.Products.Domain.Entities
{
    public sealed class InvoiceStateHistory
    {
        public int Id { get; set; }
        public string InvoiceId { get; set; } = null!;
        public DateTime OperationDate { get; set; }
        public InvoiceState State { get; set; }
    }
}