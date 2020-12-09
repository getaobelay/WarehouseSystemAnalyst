using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;
using WarehouseSystemAnalyst.Data.Helpers;

namespace WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.Configurations
{
    internal class AllocationWarehouseConfig : IEntityTypeConfiguration<AllocationWarehouse>
    {
        public void Configure(EntityTypeBuilder<AllocationWarehouse> builder)
        {
            builder.BaseWarehouseBuilder();
        }
    }
}