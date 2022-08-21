using BTech.Prodinstock.Infrastructure.Storage.Ef.Mappings;
using BTech.Prodinstock.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BTech.Prodinstock.Infrastructure.Storage.Ef
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
        }
    }
}
