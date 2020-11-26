using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Models.Data.ProductModels;

namespace WarehouseSystemAnalyst.Configurations.EntityBuilders.ProductEntities
{
    public class PalletConfig : IEntityTypeConfiguration<Pallet>
    {
        public void Configure(EntityTypeBuilder<Pallet> builder)
        {
            builder.HasKey(e => e.PalletPK);

            builder.Property(e => e.PalletID)
                    .ValueGeneratedOnAdd()
                    .IsConcurrencyToken();

            builder.HasIndex(e => e.PalletPK)
                    .IsUnique()
                    .HasFilter("[PalletPK] IS NOT NULL");

            builder.HasIndex(e => e.PalletID)
                   .IsUnique()
                   .HasFilter("[PalletID] IS NOT NULL");

            builder.HasOne(d => d.Product)
                    .WithMany(p => p.Pallets)
                    .HasForeignKey(d => d.ProductID)
                    .HasPrincipalKey(p => p.ProductID);

            builder.HasOne(d => d.Batch)
                    .WithMany(p => p.Pallets)
                    .HasForeignKey(d => d.BatcID)
                    .HasPrincipalKey(p => p.BatchID);
        }
    }
}