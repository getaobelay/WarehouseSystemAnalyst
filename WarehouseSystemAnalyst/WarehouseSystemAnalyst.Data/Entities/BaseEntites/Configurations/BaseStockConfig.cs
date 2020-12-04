using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Extensions;

namespace WarehouseSystemAnalyst.Data.Entities.BaseEntites.Configurations
{
    public class BaseStockConfig : IEntityTypeConfiguration<BaseStock>
    {
        public void Configure(EntityTypeBuilder<BaseStock> builder)
        {
            builder.BaseStockBuilder();
        }
    }
}