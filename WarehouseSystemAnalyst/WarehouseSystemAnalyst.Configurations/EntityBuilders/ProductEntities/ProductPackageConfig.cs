using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Models.Data.ProductModels;

namespace WarehouseSystemAnalyst.Configurations.EntityBuilders.ProductEntities
{
    public class ProductPackageConfig : IEntityTypeConfiguration<ProductPackages>
    {
        public void Configure(EntityTypeBuilder<ProductPackages> builder)
        {
            builder.HasKey(p => p.ProductPackagePK);

            builder.HasOne(d => d.Package)
                 .WithMany(p => p.ProductPackages)
                 .HasForeignKey(p => p.PackageID)
                 .HasPrincipalKey(p => p.PackageID);

            builder.HasOne(d => d.Product)
                  .WithMany(p => p.ProductPackages)
                  .HasForeignKey(p => p.ProductID)
                  .HasPrincipalKey(p => p.ProductID);
        }
    }
}