﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;

namespace WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.Configurations
{
    internal class ShippingWarehouseConfig : IEntityTypeConfiguration<ShippingWarehouse>
    {
        public void Configure(EntityTypeBuilder<ShippingWarehouse> builder)
        {
        }
    }
}