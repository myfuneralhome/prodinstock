using Prodinstock.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Prodinstock.Infrastructure.Storage.Ef.Mappings
{
    internal class AccountingAccountMapping : IEntityTypeConfiguration<AccountingAccount>
    {
        public void Configure(EntityTypeBuilder<AccountingAccount> builder)
        {
            builder.HasKey(aa => aa.Id);
            builder.Property(aa => aa.Id).ValueGeneratedNever();

            builder.HasOne<UserCompany>().WithMany().HasForeignKey(aa => aa.UserCompanyId);
        }
    }
}
