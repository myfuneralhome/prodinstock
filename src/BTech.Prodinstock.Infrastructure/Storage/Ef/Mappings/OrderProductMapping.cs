using BTech.Prodinstock.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BTech.Prodinstock.Infrastructure.Storage.Ef.Mappings
{
    internal class OrderProductMapping : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasKey(op => op.Id);
            builder.Property(op => op.Id).ValueGeneratedNever();

            builder.HasOne<Product>().WithMany().HasForeignKey(op => op.ProductId);
            builder.HasOne<Invoice>().WithMany(f => f.OrderProducts).HasForeignKey(op => op.InvoiceId);
        }
    }
}
