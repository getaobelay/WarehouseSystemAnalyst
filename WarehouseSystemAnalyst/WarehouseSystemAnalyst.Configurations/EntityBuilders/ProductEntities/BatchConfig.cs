using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entites.ProductEntities;
using WarehouseSystemAnalyst.Data.Models.Data.ProductModels;

namespace WarehouseSystemAnalyst.Configurations.EntityBuilders.ProductEntities
{
    public class BatchConfig : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> builder)
        {
            builder.HasKey(e => e.BatchPK);

            builder.Property(e => e.BatchID)
                    .ValueGeneratedOnAdd()
                    .IsConcurrencyToken();

            builder.HasIndex(e => e.BatchPK)
                    .IsUnique()
                    .HasFilter("[BatchPK] IS NOT NULL");

            builder.HasIndex(e => e.BatchID)
                   .IsUnique()
                   .HasFilter("[BatchID] IS NOT NULL");
        }
    }
}