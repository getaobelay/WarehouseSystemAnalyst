using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Models.Data.InventoryModels;

namespace WarehouseSystemAnalyst.Data.Configuration.InventoryEntities
{
    public class StockOutConfig : IEntityTypeConfiguration<StockOut>
    {
        public void Configure(EntityTypeBuilder<StockOut> builder)
        {

            builder.HasMany(d => d.Batches)
                .WithOne(p => p.StockOut)
                .HasForeignKey(d => d.StockOutID)
                .HasPrincipalKey(c => c.Id);

            builder.HasMany(d => d.Products)
                .WithOne(p => p.StockOut)
                .HasForeignKey(d => d.StockOutID)
                .HasPrincipalKey(c => c.Id);
        }
    }
}