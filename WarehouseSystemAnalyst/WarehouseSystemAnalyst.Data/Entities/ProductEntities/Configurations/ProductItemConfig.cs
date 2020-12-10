using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Helpers;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities.Configurations
{
    public class ProductItemConfig : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.BaseEntityBuilder();
        }
    }
}