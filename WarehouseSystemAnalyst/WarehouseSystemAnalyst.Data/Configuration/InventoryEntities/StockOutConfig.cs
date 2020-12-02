using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;

namespace WarehouseSystemAnalyst.Data.Configuration.InventoryEntities
{
    public class StockOutConfig : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {

            builder.HasMany(d => d.Batches)
                .WithOne(p => p.Inventory)
                .HasForeignKey(d => d.StockOutID)
                .HasPrincipalKey(c => c.PK);

            builder.HasMany(d => d.Products)
                .WithOne(p => p.Inventory)
                .HasForeignKey(d => d.InventoryAK)
                .HasPrincipalKey(c => c.PK);
        }
    }
}