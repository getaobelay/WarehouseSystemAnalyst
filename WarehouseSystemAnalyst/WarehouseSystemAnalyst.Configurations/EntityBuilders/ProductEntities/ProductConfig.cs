using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Models.Data.ProductModels;

namespace WarehouseSystemAnalyst.Configurations.EntityBuilders.ProductEntities
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ProductPK);

            builder.Property(e => e.ProductID)
                    .ValueGeneratedOnAdd()
                    .IsConcurrencyToken();

            builder.HasIndex(e => e.ProductPK)
                    .IsUnique()
                    .HasFilter("[ProductPK] IS NOT NULL");

            builder.HasIndex(e => e.ProductID)
                   .IsUnique()
                   .HasFilter("[ProductID] IS NOT NULL");

            builder.Property(e => e.ProductID)
                    .ValueGeneratedOnAdd()
                    .IsConcurrencyToken();

            builder.Property(e => e.ProductID)
               .ValueGeneratedOnAdd()
               .IsConcurrencyToken();

            builder.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryID)
                    .HasPrincipalKey(p => p.CategoryID);

            builder.HasMany(d => d.Batches)
                  .WithOne(p => p.Product)
                  .HasForeignKey(d => d.ProductID)
                  .HasPrincipalKey(p => p.ProductID);
        }
    }
}