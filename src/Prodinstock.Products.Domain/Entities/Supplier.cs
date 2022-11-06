namespace Prodinstock.Products.Domain.Entities
{
    public sealed class Supplier
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public List<Product> Products { get; set; } = null!;
        public string UserCompanyId { get; set; } = null!;
    }
}
