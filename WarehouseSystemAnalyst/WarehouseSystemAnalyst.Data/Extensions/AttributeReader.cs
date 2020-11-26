using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystemAnalyst.Data.Extensions
{
    /// <summary>
    /// var TblName= AttributeReader.GetTableName<YourModel>(YourContext);
    /// </summary>
    public static class AttributeReader
    {
        //Get DB Table Name
        public static string GetTableName<T>(DbContext context) where T : class
        {
            // We need dbcontext to access the models
            var models = context.Model;

            // Get all the entity types information
            var entityTypes = models.GetEntityTypes();

            // T is Name of class
            var entityTypeOfT = entityTypes.First(t => t.ClrType == typeof(T));

            var tableNameAnnotation = entityTypeOfT.GetAnnotation("Relational:TableName");
            var TableName = tableNameAnnotation.Value.ToString();
            return TableName;
        }

    }
}
