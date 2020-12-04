using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;

namespace WarehouseSystemAnalyst.Data.Entities.InventoryEntites.Configurations
{
    public class StockConfig : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasMany(d => d.Batches)
                .WithOne(p => p.Stock)
                .HasForeignKey(d => d.Stock)
                .HasPrincipalKey(c => c.PK);

            builder.HasMany(d => d.Products)
                .WithOne(p => p.Stock)
                .HasForeignKey(d => d.Inventory)
                .HasPrincipalKey(c => c.PK);
        }
    }
}