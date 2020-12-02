using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.PalletEntities;

namespace WarehouseSystemAnalyst.Data.Configuration.ProductEntities
{
    public class OrderPalletConfig : IEntityTypeConfiguration<OrderPallet>
    {
        public void Configure(EntityTypeBuilder<OrderPallet> builder)
        {

            builder.HasMany(d => d.Orders)
                   .WithMany(p => p.OrderPallets);

        }
    }
}