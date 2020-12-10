using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;
using WarehouseSystemAnalyst.Data.Helpers;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities.Configurations
{
    public class ProductSupplierConfig : IEntityTypeConfiguration<ProductVendor>
    {
        public void Configure(EntityTypeBuilder<ProductVendor> builder)
        {
            builder.BaseEntityBuilder();

            builder.HasOne(d => d.Vendor)
                  .WithMany(p => p.ProductVendors)
                  .HasForeignKey(p => p.VendorId)
                  .HasPrincipalKey(p => p.PK);

            builder.HasOne(d => d.Product)
                  .WithMany(p => p.ProductVendors)
                  .HasForeignKey(p => p.ProductId)
                  .HasPrincipalKey(p => p.PK);
        }
    }
}