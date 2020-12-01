using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Extensions
{
    public static class EntityBuilders
    {
        public static EntityTypeBuilder BasePallletBuilder<TTransaction>(this EntityTypeBuilder<TTransaction> builder)
where TTransaction : class, IBaseTransaction
        {

            builder.BaseBuilder();
            return builder;
        }
        public static EntityTypeBuilder BaseStockBuilder<TStock>(this EntityTypeBuilder<TStock> builder)
            where TStock : class, IBaseStock
        {
            builder.BaseBuilder();

            builder.Property(e => e.ProductQuantity)
                    .ValueGeneratedOnAddOrUpdate()
                   .HasDefaultValueSql("decimal(8,2)")
                   .IsRequired();

            builder.Property(e => e.BatchQuantity)
                   .ValueGeneratedOnAddOrUpdate()
                   .HasDefaultValueSql("decimal(8,2)")
                   .IsRequired();

            builder.Property(e => e.TotalUnitsQuantity)
                   .ValueGeneratedOnAddOrUpdate()
                   .HasDefaultValueSql("decimal(8,2)")
                   .IsRequired();

            return builder;
        }
        public static EntityTypeBuilder BaseMissionBuilder<TMission, TItem>(this EntityTypeBuilder<TMission> builder)
    where TMission : class, IBaseMission<TItem>
            where TItem : class, IBaseEntity
        {
            builder.BaseBuilder();

            builder.Property(e => e.AssignedTo)
                   .ValueGeneratedOnAddOrUpdate()
                   .HasMaxLength(50)
                   .IsUnicode(true)
                   .IsRequired();

            return builder;
        }
        public static EntityTypeBuilder BaseProductBuilder<TProduct>(this EntityTypeBuilder<TProduct> builder)
            where TProduct : class, IBaseProduct
        {
            builder.BaseBuilder();
            return builder;
        }
        public static EntityTypeBuilder BaseTransactionBuilder<TTransaction>(this EntityTypeBuilder<TTransaction> builder)
   where TTransaction : class, IBaseTransaction
        {
            builder.BaseBuilder();

            return builder;
        }
        public static EntityTypeBuilder BaseWarehouseBuilder<TWarehouse, TItem>(this EntityTypeBuilder<TWarehouse> builder)
where TWarehouse : class, IBaseWarehouse<TItem>

        {

            builder.BaseBuilder();

            builder.Property(e => e.WarehouseName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .ValueGeneratedOnAdd()
                .IsRequired();

            return builder;
        }
        public static EntityTypeBuilder BaseBuilder<TBaseEntity>(this EntityTypeBuilder<TBaseEntity> builder)
            where TBaseEntity : class, IBaseEntity
        {
            builder.HasKey(e => new { e.Id, e.PK });

            builder.Property(e => e.PK)
                    .ValueGeneratedOnAdd()
                    .IsConcurrencyToken();

            builder.HasIndex(e => e.Id)
                    .IsUnique()
                    .HasFilter("[Id] IS NOT NULL");

            builder.HasIndex(e => e.PK)
                   .IsUnique()
                   .HasFilter("[PK] IS NOT NULL");

            builder.Property(e => e.CreateDate)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(e => e.CreatedBy)
                   .HasMaxLength(50)
                   .IsUnicode(true)
                   .ValueGeneratedOnAddOrUpdate()
                   .IsRequired();

            builder.Property(e => e.ModifiedBy)
                   .HasMaxLength(50)
                   .IsUnicode(true)
                   .ValueGeneratedOnAddOrUpdate()
                   .IsRequired();

            return builder;
        }
    }
}