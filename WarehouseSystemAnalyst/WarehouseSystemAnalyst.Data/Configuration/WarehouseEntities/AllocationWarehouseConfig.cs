using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
namespace WarehouseSystemAnalyst.Data.Configuration.WarehouseEntities
{
    internal class AllocationWarehouseConfig : IEntityTypeConfiguration<AllocationWarehouse>
    {
        public void Configure(EntityTypeBuilder<AllocationWarehouse> builder)
        {

        }
    }
}