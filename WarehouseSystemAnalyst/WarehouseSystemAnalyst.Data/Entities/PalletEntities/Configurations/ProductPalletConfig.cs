﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WarehouseSystemAnalyst.Data.Entities.PalletEntities.Configurations
{
    public class ProductPalletConfig : IEntityTypeConfiguration<ProductPallet>
    {
        public void Configure(EntityTypeBuilder<ProductPallet> builder)
        {
            builder.HasOne(d => d.Product)
                    .WithMany(p => p.Pallets)
                    .HasForeignKey(d => d.ProductId)
                    .HasPrincipalKey(p => p.PK);

            builder.HasOne(d => d.Batch)
                    .WithMany(p => p.Pallets)
                    .HasForeignKey(d => d.BatchId)
                    .HasPrincipalKey(p => p.PK);
        }
    }
}