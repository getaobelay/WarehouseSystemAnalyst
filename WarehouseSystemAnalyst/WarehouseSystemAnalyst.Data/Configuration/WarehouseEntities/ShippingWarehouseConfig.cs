using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;

namespace WarehouseSystemAnalyst.Data.Configuration.WarehouseEntities
{
    internal class ShippingWarehouseConfig : IEntityTypeConfiguration<ShippingWarehouse>
    {
        public void Configure(EntityTypeBuilder<ShippingWarehouse> builder)
        {

        }
    }
}