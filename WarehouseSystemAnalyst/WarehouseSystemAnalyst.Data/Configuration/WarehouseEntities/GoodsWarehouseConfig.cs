using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;

namespace WarehouseSystemAnalyst.Data.Configuration.WarehouseEntities
{
    internal class GoodsWarehouseConfig : IEntityTypeConfiguration<GoodsWarehouse>
    {
        public void Configure(EntityTypeBuilder<GoodsWarehouse> builder)
        {

        }
    }
}