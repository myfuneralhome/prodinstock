using Prodinstock.Infrastructure.Storage.Ef.Mappings;
using Prodinstock.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Prodinstock.Infrastructure.Storage.Ef
{
    public sealed class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("product");

            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new InvoiceMapping());
            modelBuilder.ApplyConfiguration(new InvoiceStateHistoryMapping());
            modelBuilder.ApplyConfiguration(new SupplierMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new OrderProductMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new UserCompanyMapping());
            modelBuilder.ApplyConfiguration(new AccountingAccountMapping());
        }
    }
}
