using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entites.WarehouseEntites;

namespace WarehouseSystemAnalyst.Configurations.EntityBuilders.WarehouseEntities
{
    internal class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(e => e.LocationPK);

            builder.Property(e => e.LocationPK)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.LocationID)
                    .ValueGeneratedOnAdd()
                    .IsConcurrencyToken();

            builder.HasIndex(e => e.LocationPK)
                    .IsUnique()
                    .HasFilter("[LocationPK] IS NOT NULL");

            builder.HasIndex(e => e.LocationID)
                   .IsUnique()
                   .HasFilter("[LocationID] IS NOT NULL");

            builder.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.LocationID)
                    .HasPrincipalKey(p => p.LocationID);
        }
    }
}