using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;

namespace WarehouseSystemAnalyst.Data.Configuration.InventoryEntities
{
    public class StockInConfig : IEntityTypeConfiguration<StockIn>
    {
        public void Configure(EntityTypeBuilder<StockIn> builder)
        {
            builder.HasMany(d => d.Batches)
                .WithOne(p => p.StockIn)
                .HasForeignKey(d => d.StockInID)
                .HasPrincipalKey(c => c.Id);

            builder.HasMany(d => d.Products)
                .WithOne(p => p.StockIn)
                .HasForeignKey(d => d.StockInID)
                .HasPrincipalKey(c => c.Id);
        }
    }
}