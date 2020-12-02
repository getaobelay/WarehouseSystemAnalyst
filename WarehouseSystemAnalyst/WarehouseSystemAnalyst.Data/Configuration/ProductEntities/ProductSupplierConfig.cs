using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Data.Extensions;
namespace WarehouseSystemAnalyst.Data.Configuration.ProductEntities
{
    public class ProductSupplierConfig : IEntityTypeConfiguration<ProductVendor>
    {
        public void Configure(EntityTypeBuilder<ProductVendor> builder)
        {
            builder.BaseBuilder();

            builder.HasOne(d => d.Vendor)
                  .WithMany(p => p.ProductVendors)
                  .HasForeignKey(p => p.VendorID)
                  .HasPrincipalKey(p => p.PK);

            builder.HasOne(d => d.Product)
                  .WithMany(p => p.ProductVendors)
                  .HasForeignKey(p => p.ProductID)
                  .HasPrincipalKey(p => p.PK);
        }
    }
}