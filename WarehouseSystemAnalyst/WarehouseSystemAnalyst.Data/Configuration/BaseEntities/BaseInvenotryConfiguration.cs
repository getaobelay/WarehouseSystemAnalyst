using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Configuration.ProductEntities
{
    internal class BaseInvenotryBuilder : IEntityTypeConfiguration<BaseStock>
    {
        public void Configure(EntityTypeBuilder<BaseStock> builder)
        {
            {


            }
        }
    }
}
