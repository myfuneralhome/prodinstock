using BTech.Prodinstock.Core;

namespace BTech.Prodinstock.Products.Domain.Queries
{
    public sealed record ListSuppliers
        : IQuery<ExistingSupplier[]>
    {
    }


    public sealed class ExistingSupplier
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
