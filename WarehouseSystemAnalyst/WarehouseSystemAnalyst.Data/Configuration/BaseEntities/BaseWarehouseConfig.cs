using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Extensions;

namespace WarehouseSystemAnalyst.Data.Configuration.BaseEntities
{
    public class BaseWarehouseConfig : IEntityTypeConfiguration<BaseWarehouse>
    {
        public void Configure(EntityTypeBuilder<BaseWarehouse> builder)
        {
            builder.BaseWarehouseBuilder();
        }
    }

}
