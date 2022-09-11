using System.ComponentModel.DataAnnotations;

namespace BTech.Prodinstock.Products.Domain.UseCases.Invoices
{
    public record Buyer(
        [property: Required] string FullName,
        [property: Required] PostalAddress PostalAddress)
    { }
}