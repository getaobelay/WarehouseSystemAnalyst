using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;
using WarehouseSystemAnalyst.Data.Helpers;

namespace WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.Configurations
{
    internal class ShippingWarehouseConfig : IEntityTypeConfiguration<ShippingWarehouse>
    {
        public void Configure(EntityTypeBuilder<ShippingWarehouse> builder)
        {
            builder.BaseWarehouseBuilder();
        }
    }
}