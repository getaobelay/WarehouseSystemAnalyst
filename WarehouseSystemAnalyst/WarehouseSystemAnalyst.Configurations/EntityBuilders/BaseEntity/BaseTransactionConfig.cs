using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Services.Models.BaseEntity;

namespace WarehouseSystemAnalyst.Configurations.EntityBuilders.BaseEntity
{
    public class BaseTransactionConfig : IEntityTypeConfiguration<BaseTransaction>
    {
        public void Configure(EntityTypeBuilder<BaseTransaction> builder)
        {
            builder.HasKey(e => e.TransactionPK);

            builder.Property(e => e.TransactionID)
                    .ValueGeneratedOnAdd()
                    .IsConcurrencyToken();

            builder.HasIndex(e => e.TransactionPK)
                    .IsUnique()
                    .HasFilter("[TransactionPK] IS NOT NULL");

            builder.HasIndex(e => e.TransactionID)
                   .IsUnique()
                   .HasFilter("[TransactionID] IS NOT NULL");
        }
    }
}