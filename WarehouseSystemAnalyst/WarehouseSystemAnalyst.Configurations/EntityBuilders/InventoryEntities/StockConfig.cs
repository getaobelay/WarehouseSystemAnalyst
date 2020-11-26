using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Models.Data.InventoryModels;

namespace WarehouseSystemAnalyst.Configurations.EntityBuilders.InventoryEntities
{
    public class StockConfig : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasKey(e => e.StockPK);

            builder.Property(e => e.StockID)
                    .ValueGeneratedOnAdd()
                    .IsConcurrencyToken();

            builder.HasIndex(e => e.StockPK)
                    .IsUnique()
                    .HasFilter("[StockPK] IS NOT NULL");

            builder.HasIndex(e => e.StockID)
                   .IsUnique()
                   .HasFilter("[StockID] IS NOT NULL");

            builder.HasMany(d => d.Products)
                .WithOne(p => p.Stock)
                .HasForeignKey(d => d.StockID)
                .HasPrincipalKey(p => p.StockID);

            builder.HasMany(d => d.Batches)
                .WithOne(p => p.Stock)
                .HasForeignKey(d => d.StockID)
                .HasPrincipalKey(p => p.StockID);
        }
    }
}