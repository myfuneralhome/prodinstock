using BTech.Prodinstock.Core;

namespace BTech.Prodinstock.Products.Domain.Queries
{
    public sealed record ListCategoriesWithProductCount
        : IQuery<ExistingCategory[]>
    {
    }

    public sealed class ExistingCategory
    {
        public string? Id { get; set; }
        public string Name { get; set; } = null!;
        public int NumberOfProducts { get; set; }
    }
}
