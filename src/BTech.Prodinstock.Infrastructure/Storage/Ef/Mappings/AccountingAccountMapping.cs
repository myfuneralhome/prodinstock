using BTech.Prodinstock.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BTech.Prodinstock.Infrastructure.Storage.Ef.Mappings
{
    internal class AccountingAccountMapping : IEntityTypeConfiguration<AccountingAccount>
    {
        public void Configure(EntityTypeBuilder<AccountingAccount> builder)
        {
            builder.HasKey(aa => aa.Id);
            builder.Property(aa => aa.Id).ValueGeneratedNever();
        }
    }
}
