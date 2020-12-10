using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Helpers;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities.Configurations
{
    public class ProductPackageConfig : IEntityTypeConfiguration<ProductPackages>
    {
        public void Configure(EntityTypeBuilder<ProductPackages> builder)
        {
            builder.BaseEntityBuilder();

            builder.HasOne(d => d.Package)
                 .WithMany(p => p.ProductPackages)
                 .HasForeignKey(p => p.PackageId)
                 .HasPrincipalKey(p => p.PK);

            builder.HasOne(d => d.Product)
                  .WithMany(p => p.ProductPackages)
                  .HasForeignKey(p => p.ProductId)
                  .HasPrincipalKey(p => p.PK);
        }
    }
}