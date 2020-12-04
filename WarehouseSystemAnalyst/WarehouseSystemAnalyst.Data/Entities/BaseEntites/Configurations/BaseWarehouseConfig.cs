using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Extensions;

namespace WarehouseSystemAnalyst.Data.Entities.BaseEntites.Configurations
{
    public class BaseWarehouseConfig : IEntityTypeConfiguration<BaseWarehouse>
    {
        public void Configure(EntityTypeBuilder<BaseWarehouse> builder)
        {
            builder.BaseWarehouseBuilder();
        }
    }
}