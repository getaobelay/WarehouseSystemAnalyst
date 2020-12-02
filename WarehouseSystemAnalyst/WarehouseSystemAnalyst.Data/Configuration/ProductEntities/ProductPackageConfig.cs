using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Extensions;

namespace WarehouseSystemAnalyst.Data.Configuration.ProductEntities
{
    public class ProductPackageConfig : IEntityTypeConfiguration<ProductPackages>
    {
        public void Configure(EntityTypeBuilder<ProductPackages> builder)
        {
            builder.BaseBuilder();

            builder.HasOne(d => d.Package)
                 .WithMany(p => p.ProductPackages)
                 .HasForeignKey(p => p.PackageID)
                 .HasPrincipalKey(p => p.PK);

            builder.HasOne(d => d.Product)
                  .WithMany(p => p.ProductPackages)
                  .HasForeignKey(p => p.ProductID)
                  .HasPrincipalKey(p => p.PK);
        }
    }
}