using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Helpers;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities.Configurations
{
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.BaseEntityBuilder();


            builder.HasMany(d => d.SubCategories)
                  .WithOne(p => p.Category)
                  .HasForeignKey(d => d.CategoryId)
                  .HasPrincipalKey(p => p.PK);
        }
    }
}