using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;

namespace WarehouseSystemAnalyst.Data.Configuration.BaseEntities
{
    internal class ProductEntityBuilder : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(d => d.Category)
                  .WithMany(p => p.Products)
                  .HasForeignKey(d => d.CategoryID)
                  .HasPrincipalKey(p => p.Id);

            builder.HasMany(d => d.Batches)
                  .WithOne(p => p.Product)
                  .HasForeignKey(d => d.ProductID)
                  .HasPrincipalKey(p => p.Id);
        }
    }
}