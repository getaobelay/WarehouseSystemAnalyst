using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;

namespace WarehouseSystemAnalyst.Data.Configuration.BaseEntities
{
    internal class CategoryEntityBuilder : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasMany(d => d.SubCategories)
                  .WithOne(p => p.Category)
                  .HasForeignKey(d => d.CategoryId)
                  .HasPrincipalKey(p => p.Id);
        }
    }
}