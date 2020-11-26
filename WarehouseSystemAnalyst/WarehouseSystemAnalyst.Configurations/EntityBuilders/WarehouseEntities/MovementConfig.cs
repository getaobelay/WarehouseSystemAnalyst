using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Models.Data.WarehouseModels;

namespace WarehouseSystemAnalyst.Configurations.EntityBuilders.WarehouseEntities
{
    internal class MovementConfig : IEntityTypeConfiguration<Movement>
    {
        public void Configure(EntityTypeBuilder<Movement> builder)
        {
            builder.HasKey(e => e.MovementPK);

            builder.Property(e => e.MovementPK)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.MovementID)
                    .ValueGeneratedOnAdd()
                    .IsConcurrencyToken();

            builder.HasIndex(e => e.MovementPK)
                    .IsUnique()
                    .HasFilter("[MovementPK] IS NOT NULL");

            builder.HasIndex(e => e.MovementID)
                   .IsUnique()
                   .HasFilter("[MovementID] IS NOT NULL");

            builder.HasOne(d => d.Product)
                 .WithMany(p => p.Movements)
                 .HasForeignKey(d => d.ProductID)
                 .HasPrincipalKey(p => p.ProductID);

            builder.HasOne(d => d.Warehouse)
                 .WithMany(p => p.Movements)
                 .HasForeignKey(d => d.WarehouseID)
                 .HasPrincipalKey(p => p.WarehouseID);

            builder.HasOne(d => d.Location)
                 .WithMany(p => p.Movements)
                 .HasForeignKey(d => d.LocationID)
                 .HasPrincipalKey(p => p.LocationID);

            builder.HasOne(d => d.ProductPackage)
                 .WithMany(p => p.Movements)
                 .HasForeignKey(d => d.ProductPackageID)
                 .HasPrincipalKey(p => p.ProductPackageID);

            builder.HasOne(d => d.Batch)
              .WithMany(p => p.Movements)
              .HasForeignKey(d => d.BatchID)
              .HasPrincipalKey(p => p.BatchID);

            builder.HasOne(d => d.Employee)
                 .WithMany(p => p.Movements)
                 .HasForeignKey(d => d.EmployeeID)
                 .HasPrincipalKey(p => p.EmployeeID);
        }
    }
}