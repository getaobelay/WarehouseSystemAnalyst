using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Models.Data.ProductModels;

namespace WarehouseSystemAnalyst.Configurations.EntityBuilders.ProductEntities
{
    public class ProductSupplierConfig : IEntityTypeConfiguration<ProductSuppliers>
    {
        public void Configure(EntityTypeBuilder<ProductSuppliers> builder)
        {
            builder.HasKey(p => p.ProductSupplierPK);

            builder.HasOne(d => d.Suppliers)
                  .WithMany(p => p.ProductSuppliers)
                  .HasForeignKey(p => p.SupplierID)
                  .HasPrincipalKey(p => p.SupplierID);

            builder.HasOne(d => d.Product)
                  .WithMany(p => p.ProductSuppliers)
                  .HasForeignKey(p => p.ProductID)
                  .HasPrincipalKey(p => p.ProductID);
        }
    }
}