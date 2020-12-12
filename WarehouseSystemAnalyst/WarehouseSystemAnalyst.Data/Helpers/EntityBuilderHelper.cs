using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Helpers
{
    public static class EntityBuilderHelper
    {
        public static EntityTypeBuilder BasePallletBuilder<TBasePallet>(this EntityTypeBuilder<TBasePallet> builder)
            where TBasePallet : class, IBasePallet, new()
        {
            builder.BaseEntityBuilder();
            return builder;
        }

        public static EntityTypeBuilder BaseStockBuilder<TStock>(this EntityTypeBuilder<TStock> builder)
            where TStock : class, IBaseStock, new()
        {
            builder.BaseEntityBuilder();

            builder.Property(e => e.ProductQuantity)
                   .HasColumnType("decimal(8,2)")
                   .IsRequired();

            builder.Property(e => e.BatchQuantity)
                   .HasColumnType("decimal(8,2)")
                   .IsRequired();

            builder.Property(e => e.TotalUnitsQuantity)
                   .HasColumnType("decimal(8,2)")
                   .IsRequired();

            return builder;
        }

        public static EntityTypeBuilder BaseMissionBuilder<TMission, TItem>(this EntityTypeBuilder<TMission> builder)
            where TMission : class, IBaseMission<TItem>, new()
            where TItem : class, IBaseEntity, new()
        {
            builder.BaseEntityBuilder();

            builder.Property(e => e.AssignedTo)
                   .ValueGeneratedOnAddOrUpdate()
                   .HasMaxLength(50)
                   .IsUnicode(true)
                   .IsRequired();

            return builder;
        }


        public static EntityTypeBuilder BaseWarehouseBuilder<TWarehouse>(this EntityTypeBuilder<TWarehouse> builder)
            where TWarehouse : class, IBaseWarehouse, new()

        {
            builder.BaseEntityBuilder();

            builder.Property(e => e.WarehouseName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .ValueGeneratedOnAdd()
                .IsRequired();

            return builder;
        }

        public static EntityTypeBuilder BaseEntityBuilder<TBaseEntity>(this EntityTypeBuilder<TBaseEntity> builder)
            where TBaseEntity : class, IBaseEntity, new()
        {

            builder.HasKey(p => new { p.Id, p.PK })
                   .IsClustered(true);

            builder.Property(e => e.Id)
                    .UseIdentityColumn();

            builder.Property(e => e.PK)
                .ValueGeneratedOnAdd();

            builder.HasIndex(e => e.PK)
                    .IsUnique()
                    .HasFilter("[PK] IS NOT NULL");

            builder.Property(e => e.CreateDate)
                   .ValueGeneratedOnAdd()
                   .IsRequired();

            builder.Property(e => e.CreatedBy)
                   .HasMaxLength(50)
                   .IsUnicode(true)
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.ModifiedBy)
                   .HasMaxLength(50)
                   .IsUnicode(true);


            return builder;
        }
    }
}