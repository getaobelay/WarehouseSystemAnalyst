using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WarehouseSystemAnalyst.Data.Entities.PalletEntities.Configurations
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