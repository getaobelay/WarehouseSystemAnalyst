using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Helpers;

namespace WarehouseSystemAnalyst.Data.Entities.ProductEntities.Configurations
{
    public class ProductMesuresConfig : IEntityTypeConfiguration<ProductMesures>
    {
        public void Configure(EntityTypeBuilder<ProductMesures> builder)
        {
            builder.BaseBuilder();
            builder.HasOne(d => d.Mesure)
                  .WithMany(p => p.ProductMesures)
                  .HasForeignKey(p => p.MesureId)
                  .HasPrincipalKey(p => p.PK);

            builder.HasOne(d => d.Product)
                  .WithMany(p => p.Mesures)
                  .HasForeignKey(p => p.ProductId)
                  .HasPrincipalKey(p => p.PK);
        }
    }
}