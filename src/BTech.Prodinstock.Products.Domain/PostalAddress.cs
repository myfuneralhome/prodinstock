using System.ComponentModel.DataAnnotations;

namespace BTech.Prodinstock.Products.Domain
{
    public record PostalAddress(
        string City,
        string Street,
        string PostalCode)
    { }
}