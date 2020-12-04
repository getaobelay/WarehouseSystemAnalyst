using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Implementation.BaseRepositories;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Base;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace WarehouseSystemAnalyst.Data
{
    public static class DataServices
    {
        public static IServiceCollection GetServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IUnitOfWorkRepository<>), typeof(UnitOfWorkRepository<>));
            services.AddTransient(typeof(ITransactionRepository<,>), typeof(BaseTransactionRepository<,>));
            services.AddTransient(typeof(IInventoryRepository<,>), typeof(InventoryRepository<,>));

            return services;
        }
    }
}
