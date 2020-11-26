using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Models.Data.TransactionModels;

namespace WarehouseSystemAnalyst.Configurations.EntityBuilders.TransactionEntities
{
    internal class ProductTransactionConfig : IEntityTypeConfiguration<ProductTransaction>
    {
        public void Configure(EntityTypeBuilder<ProductTransaction> builder)
        {
            builder.HasOne(d => d.Movement)
                 .WithMany(p => p.ProductTransactions)
                 .HasForeignKey(d => d.MovementID)
                 .HasPrincipalKey(p => p.MovementID);

            builder.HasOne(d => d.Product)
                  .WithMany(p => p.ProductTransactions)
                  .HasForeignKey(d => d.ProductID)
                  .HasPrincipalKey(p => p.ProductID);
        }
    }
}