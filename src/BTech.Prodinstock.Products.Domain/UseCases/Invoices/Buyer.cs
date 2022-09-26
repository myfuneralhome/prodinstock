using System.ComponentModel.DataAnnotations;

namespace BTech.Prodinstock.Products.Domain.UseCases.Invoices
{
    public record Buyer(
        string FullName,
        PostalAddress PostalAddress)
    { }
}