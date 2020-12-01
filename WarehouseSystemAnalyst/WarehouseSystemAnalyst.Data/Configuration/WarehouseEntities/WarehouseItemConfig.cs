using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;

namespace WarehouseSystemAnalyst.Data.Configuration.WarehouseEntities
{
    internal class WarehouseItemConfig : IEntityTypeConfiguration<WarehouseItem>
    {
        public void Configure(EntityTypeBuilder<WarehouseItem> builder)
        {


            builder.HasOne(d => d.Product)
                 .WithMany(p => p.WarehouseItems)
                 .HasForeignKey(d => d.ProductID)
                 .HasPrincipalKey(p => p.Id);

            builder.HasOne(d => d.AllocationWarehouse)
                 .WithMany(p => p.WarehouseItems)
                 .HasForeignKey(d => d.AllocationWarehouse)
                 .HasPrincipalKey(p => p.Id);

            builder.HasOne(d => d.GoodsWarehouse)
               .WithMany(p => p.WarehouseItems)
               .HasForeignKey(d => d.AllocationWarehouse)
               .HasPrincipalKey(p => p.Id);

            builder.HasOne(d => d.ShippingWarehouse)
               .WithMany(p => p.WarehouseItems)
               .HasForeignKey(d => d.AllocationWarehouse)
               .HasPrincipalKey(p => p.Id);

            builder.HasOne(d => d.Location)
                 .WithMany(p => p.WarehouseItems)
                 .HasForeignKey(d => d.LocationID)
                 .HasPrincipalKey(p => p.Id);

            builder.HasOne(d => d.ProductPackage)
                 .WithMany(p => p.WarehouseItems)
                 .HasForeignKey(d => d.ProductPackageID)
                 .HasPrincipalKey(p => p.Id);

            builder.HasOne(d => d.Batch)
              .WithMany(p => p.WarehouseItems)
              .HasForeignKey(d => d.BatchID)
              .HasPrincipalKey(p => p.Id);

            builder.HasOne(d => d.Employee)
                 .WithMany(p => p.WarehouseItems)
                 .HasForeignKey(d => d.EmployeeID)
                 .HasPrincipalKey(p => p.Id);
        }
    }
}