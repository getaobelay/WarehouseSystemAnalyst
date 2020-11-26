using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entites.TrasnactionEntites;

namespace WarehouseSystemAnalyst.Configurations.EntityBuilders.TransactionEntities
{
    internal class EmployeeTransactionConfig : IEntityTypeConfiguration<EmployeeTransaction>
    {
        public void Configure(EntityTypeBuilder<EmployeeTransaction> builder)
        {
            builder.HasOne(d => d.Movement)
                 .WithMany(p => p.EmployeeTransactions)
                 .HasForeignKey(d => d.MovementID)
                 .HasPrincipalKey(p => p.MovementID);

            builder.HasOne(d => d.Employee)
                  .WithMany(p => p.Transactions)
                  .HasForeignKey(d => d.EmployeeID)
                  .HasPrincipalKey(p => p.EmployeeID);
        }
    }
}