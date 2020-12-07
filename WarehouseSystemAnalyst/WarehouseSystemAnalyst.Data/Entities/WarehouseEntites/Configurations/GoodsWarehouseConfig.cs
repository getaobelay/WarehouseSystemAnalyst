using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;
using WarehouseSystemAnalyst.Data.Extensions;

namespace WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.Configurations
{
    internal class GoodsWarehouseConfig : IEntityTypeConfiguration<GoodsWarehouse>
    {
        public void Configure(EntityTypeBuilder<GoodsWarehouse> builder)
        {
            builder.BaseWarehouseBuilder();

        }
    }
}