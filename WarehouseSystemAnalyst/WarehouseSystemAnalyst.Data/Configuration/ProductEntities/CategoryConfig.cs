using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Extensions;

namespace WarehouseSystemAnalyst.Data.Configuration.BaseEntities
{
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.BaseBuilder();
            builder.HasMany(d => d.SubCategories)
                  .WithOne(p => p.Category)
                  .HasForeignKey(d => d.CategoryId)
                  .HasPrincipalKey(p => p.PK);
        }
    }
}