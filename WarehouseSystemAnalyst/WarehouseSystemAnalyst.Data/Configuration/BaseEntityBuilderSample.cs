using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystemAnalyst.Data.Configuration.BaseEntities
{
    public class BaseEntityBuilderSample<TBaseEntity> : IEntityTypeConfiguration<TBaseEntity>
        where TBaseEntity : class
    {
        public void Configure(EntityTypeBuilder<TBaseEntity> builder)
        {
            var entityTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => !string.IsNullOrEmpty(x.Namespace)
                    && x.BaseType != null
                    && x.BaseType == typeof(TBaseEntity)).ToList();
        }
    }
}
