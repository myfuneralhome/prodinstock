namespace BTech.Prodinstock.Products.Domain.Entities
{
    public sealed class AccountingAccount
    {
        public int Id { get; set; }
        public short Number  { get; set; }
        public string Description { get; set; } = null!;
        public string UserCompanyId { get; set; } = null!;
    }
}
