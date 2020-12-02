using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Extensions;

namespace WarehouseSystemAnalyst.Data.Configuration.ProductEntities
{
    public class ProductItemConfig : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.BaseBuilder();
        }
    }
}