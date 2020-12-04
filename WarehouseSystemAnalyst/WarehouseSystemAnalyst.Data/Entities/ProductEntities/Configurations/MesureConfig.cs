using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Extensions;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities.Configurations
{
    public class MesureConfig : IEntityTypeConfiguration<Mesure>
    {
        public void Configure(EntityTypeBuilder<Mesure> builder)
        {
            builder.BaseBuilder();
        }
    }
}