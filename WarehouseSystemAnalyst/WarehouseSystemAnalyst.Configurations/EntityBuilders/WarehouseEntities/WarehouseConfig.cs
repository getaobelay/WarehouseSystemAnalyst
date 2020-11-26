using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Models.Data.WarehouseModels;

namespace WarehouseSystemAnalyst.Configurations.EntityBuilders.WarehouseEntities
{
    internal class WarehouseConfig : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(e => e.WarehousePK);

            builder.Property(e => e.WarehousePK)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.WarehouseID)
                    .ValueGeneratedOnAdd()
                    .IsConcurrencyToken();

            builder.HasIndex(e => e.WarehousePK)
                    .IsUnique()
                    .HasFilter("[WarehousePK] IS NOT NULL");

            builder.HasIndex(e => e.WarehouseID)
                   .IsUnique()
                   .HasFilter("[WarehouseID] IS NOT NULL");
        }
    }
}