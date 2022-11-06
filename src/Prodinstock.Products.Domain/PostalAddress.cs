using System.ComponentModel.DataAnnotations;

namespace Prodinstock.Products.Domain
{
    public record PostalAddress(
        string City,
        string Street,
        string PostalCode)
    { }
}