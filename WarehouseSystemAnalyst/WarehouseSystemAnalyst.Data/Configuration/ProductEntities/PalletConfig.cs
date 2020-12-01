using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.PalletEntities;

namespace WarehouseSystemAnalyst.Data.Configuration.ProductEntities
{
    public class PalletConfig : IEntityTypeConfiguration<ProductPallet>
    {
        public void Configure(EntityTypeBuilder<ProductPallet> builder)
        {

            builder.HasOne(d => d.Product)
                    .WithMany(p => p.Pallets)
                    .HasForeignKey(d => d.ProductID)
                    .HasPrincipalKey(p => p.Id);

            builder.HasOne(d => d.Batch)
                    .WithMany(p => p.Pallets)
                    .HasForeignKey(d => d.BatcID)
                    .HasPrincipalKey(p => p.Id);
        }
    }
}