using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entites.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Configuration.BaseEntities
{
    public class BaseEntityBuilder : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
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
                       .HasMaxLength(100)
                       .ValueGeneratedOnAddOrUpdate()
                       .IsRequired();


                builder.Property(e => e.ModifiedBy)
                       .HasMaxLength(100)
                       .ValueGeneratedOnAddOrUpdate()
                       .IsRequired();

                builder.Property(e => e.ModifiedDate)
                       .ValueGeneratedOnAddOrUpdate()
                       .IsRequired();

            }
        }
    }
}
