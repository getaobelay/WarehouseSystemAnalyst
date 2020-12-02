using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.SupplyChainEntities;

namespace WarehouseSystemAnalyst.Data.Configuration.InventoryEntities
{
    public class SupplierConfig : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {

        }
    }
}