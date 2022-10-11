using BTech.Prodinstock.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BTech.Prodinstock.Infrastructure.Storage.Ef.Mappings
{
    internal class UserCompanyMapping : IEntityTypeConfiguration<UserCompany>
    {
        public void Configure(EntityTypeBuilder<UserCompany> builder)
        {
            builder.HasKey(uc => uc.Id);
            builder.Property(uc => uc.Id).ValueGeneratedNever();

            builder.HasMany<User>().WithOne().HasForeignKey(u => u.UserCompanyId);
        }
    }
}
