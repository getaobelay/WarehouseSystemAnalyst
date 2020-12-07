using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Extensions;

namespace WarehouseSystemAnalyst.Data.Entities.InventoryEntites.Configurations
{
    public class StockConfig : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.BaseStockBuilder();

            builder.HasMany(d => d.Batches)
                .WithOne(p => p.Stock)
                .HasForeignKey(d => d.StockId)
                .HasPrincipalKey(c => c.PK);

            builder.HasMany(d => d.Products)
                .WithOne(p => p.Stock)
                .HasForeignKey(d => d.StockAK)
                .HasPrincipalKey(c => c.PK);
        }
    }
}