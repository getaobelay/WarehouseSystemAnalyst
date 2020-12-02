using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Extensions;

namespace WarehouseSystemAnalyst.Data.Configuration.ProductEntities
{
    public class ProductMesuresConfig : IEntityTypeConfiguration<ProductMesures>
    {
        public void Configure(EntityTypeBuilder<ProductMesures> builder)
        {
            builder.BaseBuilder();
            builder.HasOne(d => d.Mesure)
                  .WithMany(p => p.ProductMesures)
                  .HasForeignKey(p => p.MesureID)
                  .HasPrincipalKey(p => p.PK);

            builder.HasOne(d => d.Product)
                  .WithMany(p => p.Mesures)
                  .HasForeignKey(p => p.ProductID)
                  .HasPrincipalKey(p => p.PK);
        }
    }
}