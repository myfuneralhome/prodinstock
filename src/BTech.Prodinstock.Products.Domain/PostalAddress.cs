using System.ComponentModel.DataAnnotations;

namespace BTech.Prodinstock.Products.Domain
{
    public record PostalAddress(
        [property: Required] string City,
        [property: Required] string Street,
        [property: Required] string PostalCode)
    { }
}