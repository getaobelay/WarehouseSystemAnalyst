using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entites.BaseEntites;
using WarehouseSystemAnalyst.Data.Entites.ProductEntities;

namespace WarehouseSystemAnalyst.Data.Configuration.BaseEntities
{
    internal class ProductEntityBuilder : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            {


            }
        }
    }
}
