using Prodinstock.Core;

namespace Prodinstock.Products.Domain.Queries
{
    public sealed record SearchAccountingAccount
        (string ValueSearch)
        : IQuery<ExistingAccountingAccount[]>
    {
    }

    public sealed class ExistingAccountingAccount
    {
        public int Id { get; set; }
        public short Number { get; set; }
        public string Description { get; set; } = null!;
    }
}
