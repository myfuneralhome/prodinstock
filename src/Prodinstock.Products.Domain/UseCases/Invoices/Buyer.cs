namespace Prodinstock.Products.Domain.UseCases.Invoices
{
    public record Buyer(
        string FullName,
        PostalAddress PostalAddress)
    { }
}
