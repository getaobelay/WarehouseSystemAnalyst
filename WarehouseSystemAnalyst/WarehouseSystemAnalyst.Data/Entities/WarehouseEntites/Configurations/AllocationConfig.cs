using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.Configurations
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