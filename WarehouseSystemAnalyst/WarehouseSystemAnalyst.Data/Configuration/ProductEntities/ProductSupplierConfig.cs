using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;

namespace WarehouseSystemAnalyst.Data.Configuration.ProductEntities
{
    public class ProductSupplierConfig : IEntityTypeConfiguration<ProductSuppliers>
    {
        public void Configure(EntityTypeBuilder<ProductSuppliers> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(d => d.Suppliers)
                  .WithMany(p => p.ProductSuppliers)
                  .HasForeignKey(p => p.SupplierID)
                  .HasPrincipalKey(p => p.SupplierID);

            builder.HasOne(d => d.Product)
                  .WithMany(p => p.ProductSuppliers)
                  .HasForeignKey(p => p.ProductID)
                  .HasPrincipalKey(p => p.Id);
        }
    }
}