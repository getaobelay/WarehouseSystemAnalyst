using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;

namespace WarehouseSystemAnalyst.Data.Entities.InventoryEntites.Configurations
{
    public class SupplierConfig : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
        }
    }
}