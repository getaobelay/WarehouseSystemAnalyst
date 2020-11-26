using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Models.Data.InventoryModels;

namespace WarehouseSystemAnalyst.Configurations.EntityBuilders.InventoryEntities
{
    public class InventoryConfig : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(e => e.InventoryPK);

            builder.Property(e => e.InventoryID)
                    .ValueGeneratedOnAdd()
                    .IsConcurrencyToken();

            builder.HasIndex(e => e.InventoryPK)
                    .IsUnique()
                    .HasFilter("[InventoryPK] IS NOT NULL");

            builder.HasIndex(e => e.InventoryID)
                   .IsUnique()
                   .HasFilter("[InventoryID] IS NOT NULL");

            builder.HasMany(d => d.Batches)
                .WithOne(p => p.Inventory)
                .HasForeignKey(d => d.InventoryID)
                .HasPrincipalKey(c => c.InventoryID);

            builder.HasMany(d => d.Products)
                .WithOne(p => p.Inventory)
                .HasForeignKey(d => d.InventoryID)
                .HasPrincipalKey(c => c.InventoryID);
        }
    }
}