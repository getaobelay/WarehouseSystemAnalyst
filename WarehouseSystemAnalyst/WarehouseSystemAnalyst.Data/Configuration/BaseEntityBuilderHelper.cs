using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entites.BaseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Configuration
{
    public static class BaseEntityBuilderHelper
    {
        public static EntityTypeBuilder BuilderBaseEntity<IBaseEntity>(this EntityTypeBuilder<IBaseEntity> builder)
            where IBaseEntity : class
        {
            var entityTypes = Assembly.GetExecutingAssembly()
             .GetTypes()
             .Where(x => !string.IsNullOrEmpty(x.Namespace)
                 && x.BaseType != null
                 && x.BaseType == typeof(IBaseEntity)).ToList();

            return builder;
        }
    }
}
