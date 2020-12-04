using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Extensions;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities.Configurations
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.BaseBuilder();
            builder.HasOne(d => d.Category)
                  .WithMany(p => p.Products)
                  .HasForeignKey(d => d.CategoryAK)
                  .HasPrincipalKey(p => p.PK);

            builder.HasMany(d => d.Batches)
                  .WithOne(p => p.Product)
                  .HasForeignKey(d => d.ProductID)
                  .HasPrincipalKey(p => p.PK);
        }
    }
}