using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entites.InventoryEntites;

namespace WarehouseSystemAnalyst.Configurations.EntityBuilders.InventoryEntities
{
    public class SupplierConfig : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(e => e.SupplierPK);

            builder.Property(e => e.SupplierID)
                    .ValueGeneratedOnAdd()
                    .IsConcurrencyToken();

            builder.HasIndex(e => e.SupplierPK)
                    .IsUnique()
                    .HasFilter("[SupplierPK] IS NOT NULL");

            builder.HasIndex(e => e.SupplierID)
                   .IsUnique()
                   .HasFilter("[SupplierID] IS NOT NULL");
        }
    }
}