using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;

namespace WarehouseSystemAnalyst.Data.Configuration.InventoryEntities
{
    public class StockInConfig : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasMany(d => d.Batches)
                .WithOne(p => p.Stock)
                .HasForeignKey(d => d.StockInID)
                .HasPrincipalKey(c => c.PK);

            builder.HasMany(d => d.Products)
                .WithOne(p => p.Stock)
                .HasForeignKey(d => d.StockID)
                .HasPrincipalKey(c => c.PK);
        }
    }
}