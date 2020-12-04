using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;

namespace WarehouseSystemAnalyst.Data.Entities.InventoryEntites.Configurations
{
    public class InventoryConfig : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasMany(d => d.Batches)
                .WithOne(p => p.Inventory)
                .HasForeignKey(d => d.Stock)
                .HasPrincipalKey(c => c.PK);

            builder.HasMany(d => d.Products)
                .WithOne(p => p.Inventory)
                .HasForeignKey(d => d.Inventory)
                .HasPrincipalKey(c => c.PK);
        }
    }
}