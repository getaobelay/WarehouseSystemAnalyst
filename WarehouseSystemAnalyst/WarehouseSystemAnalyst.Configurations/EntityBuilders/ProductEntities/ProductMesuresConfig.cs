using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Models.Data.ProductModels;

namespace WarehouseSystemAnalyst.Configurations.EntityBuilders.ProductEntities
{
    public class ProductMesuresConfig : IEntityTypeConfiguration<ProductMesures>
    {
        public void Configure(EntityTypeBuilder<ProductMesures> builder)
        {
            builder.HasKey(p => p.ProductMesuresPK);

            builder.HasOne(d => d.Mesure)
                  .WithMany(p => p.ProductMesures)
                  .HasForeignKey(p => p.MesureID)
                  .HasPrincipalKey(p => p.MesureID);

            builder.HasOne(d => d.Product)
                  .WithMany(p => p.Mesures)
                  .HasForeignKey(p => p.ProductID)
                  .HasPrincipalKey(p => p.ProductID);
        }
    }
}