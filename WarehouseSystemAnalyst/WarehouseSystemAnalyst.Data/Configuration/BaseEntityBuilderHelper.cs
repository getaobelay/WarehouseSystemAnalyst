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
        public static EntityTypeBuilder BuilderBaseEntity<BaseEntity>(this EntityTypeBuilder<IBaseEntity> builder)
            where BaseEntity : class, IBaseEntity, new()
        {
            var entityTypes = Assembly.GetExecutingAssembly()
             .GetTypes()
             .Where(x => !string.IsNullOrEmpty(x.Namespace)
                 && x.BaseType != null
                 && x.BaseType == typeof(IBaseEntity)).ToList();

            foreach (var entity in entityTypes)
            {

            }
            return builder;
        }
    }
}
