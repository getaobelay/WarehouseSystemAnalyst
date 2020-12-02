using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Extensions;

namespace WarehouseSystemAnalyst.Data.Configuration.ProductEntities
{
    public class BatchConfig : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> builder)
        {
            builder.BaseBuilder();
            builder.HasOne(p=> p.ProductItem)
                   .WithMany(b=> b.Batches)
                   .HasForeignKey(p => p.ProductItemId)
                   .HasPrincipalKey(p => p.PK);
        }
    }
}