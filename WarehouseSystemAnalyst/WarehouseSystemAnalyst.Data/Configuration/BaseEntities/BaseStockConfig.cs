using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Extensions;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Configuration.BaseEntities
{
    public class BaseStockConfig : IEntityTypeConfiguration<BaseStock>
    {
        public void Configure(EntityTypeBuilder<BaseStock> builder)
        {
            builder.BaseStockBuilder();
        }
    }

}
