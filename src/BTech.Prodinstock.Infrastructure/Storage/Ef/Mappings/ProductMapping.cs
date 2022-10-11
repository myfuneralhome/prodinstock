using BTech.Prodinstock.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BTech.Prodinstock.Infrastructure.Storage.Ef.Mappings
{
    internal class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).ValueGeneratedNever();

            builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(p => p.Supplier).WithMany(s => s.Products).HasForeignKey(p => p.SupplierId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne<AccountingAccount>().WithMany().HasForeignKey(p => p.AccountingAccountId).OnDelete(DeleteBehavior.SetNull);

            builder.HasOne<UserCompany>().WithMany().HasForeignKey(p => p.UserCompanyId);
        }
    }
}
