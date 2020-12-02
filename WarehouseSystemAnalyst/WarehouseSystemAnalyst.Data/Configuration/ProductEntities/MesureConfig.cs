using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Extensions;

namespace WarehouseSystemAnalyst.Data.Configuration.ProductEntities
{
    public class MesureConfig : IEntityTypeConfiguration<Mesure>
    {
        public void Configure(EntityTypeBuilder<Mesure> builder)
        {
            builder.BaseBuilder();
        }
    }
}