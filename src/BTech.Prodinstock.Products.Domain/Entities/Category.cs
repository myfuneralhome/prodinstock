namespace BTech.Prodinstock.Products.Domain.Entities
{
    public sealed class Category
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;

        public List<Product> Products { get; set; }
    }
}
