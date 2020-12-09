using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Helpers;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities.Configurations
{
    public class BatchConfig : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> builder)
        {
            builder.BaseBuilder();
            builder.HasOne(p => p.ProductItem)
                   .WithMany(b => b.Batches)
                   .HasForeignKey(p => p.ProductItemId)
                   .HasPrincipalKey(p => p.PK);
        }
    }
}