using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;

namespace WarehouseSystemAnalyst.Data.Configuration.WarehouseEntities
{
    public class AllocationConfig : IEntityTypeConfiguration<Allocation>
    {
        public void Configure(EntityTypeBuilder<Allocation> builder)
        {
            builder.HasOne(o => o.Order)
              .WithMany(w => w.Allocations)
              .HasForeignKey(o => o.OrderID)
              .HasPrincipalKey(w => w.PK);

            builder.HasMany(d => d.WarehouseItems)
                 .WithOne(p => p.Allocation)
                 .HasForeignKey(d => d.AllocationId)
                 .HasPrincipalKey(p => p.PK);
        }
    }
}
