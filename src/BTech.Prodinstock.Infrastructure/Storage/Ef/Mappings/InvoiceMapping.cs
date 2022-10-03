using BTech.Prodinstock.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BTech.Prodinstock.Infrastructure.Storage.Ef.Mappings
{
    internal class InvoiceMapping : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedNever();

            builder.HasMany(i => i.InvoiceStateHistories).WithOne().HasForeignKey(ish => ish.InvoiceId);
            builder.Navigation(i => i.InvoiceStateHistories).AutoInclude();
            builder.Navigation(i => i.OrderProducts).AutoInclude();

            builder.OwnsOne(i => i.BuyerPostalAddress);
        }
    }
}