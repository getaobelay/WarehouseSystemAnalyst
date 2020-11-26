using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Models.Data.TransactionModels;

namespace WarehouseSystemAnalyst.Configurations.EntityBuilders.TransactionEntities
{
    internal class WarehouseTransactionConfig : IEntityTypeConfiguration<WarehouseTransaction>
    {
        public void Configure(EntityTypeBuilder<WarehouseTransaction> builder)
        {
            builder.HasOne(d => d.Warehouse)
                 .WithMany(p => p.Transactions)
                 .HasForeignKey(d => d.WarehouseID)
                 .HasPrincipalKey(p => p.WarehouseID);

            builder.HasOne(d => d.Movement)
                  .WithMany(p => p.WarehouseTransactions)
                  .HasForeignKey(d => d.MovementID)
                  .HasPrincipalKey(p => p.MovementID);
            ;
        }
    }
}