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

            builder.Property(d => d.CreationDate).ValueGeneratedOnAdd();
        }
    }
}
