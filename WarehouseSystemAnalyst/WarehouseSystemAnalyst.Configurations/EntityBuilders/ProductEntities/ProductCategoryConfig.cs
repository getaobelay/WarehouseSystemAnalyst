using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Models.Data.ProductModels;

namespace WarehouseSystemAnalyst.Configurations.EntityBuilders.ProductEntities
{
    public class ProductCategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.CategoryPK);

            builder.Property(e => e.CategoryPK)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.CategoryID)
                    .ValueGeneratedOnAdd()
                    .IsConcurrencyToken();

            builder.HasIndex(e => e.CategoryPK)
                    .IsUnique()
                    .HasFilter("[CategoryPK] IS NOT NULL");

            builder.HasIndex(e => e.CategoryID)
                   .IsUnique()
                   .HasFilter("[CategoryID] IS NOT NULL");
        }
    }
}