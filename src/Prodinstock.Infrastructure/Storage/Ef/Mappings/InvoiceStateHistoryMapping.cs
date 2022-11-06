using Prodinstock.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Prodinstock.Infrastructure.Storage.Ef.Mappings
{
    internal class InvoiceStateHistoryMapping : IEntityTypeConfiguration<InvoiceStateHistory>
    {
        public void Configure(EntityTypeBuilder<InvoiceStateHistory> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
        }
    }
}