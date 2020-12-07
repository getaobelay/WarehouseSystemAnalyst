using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace WarehouseSystemAnalyst.DataTests.Implementation
{
    public abstract class BaseRespositoryTest
    {
        public IUnitOfWorkRepository<WarehouseDbContext> GetUnitOfWork(string database)
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<WarehouseDbContext>()
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            var context = new WarehouseDbContext(options);

            return new UnitOfWorkRepository<WarehouseDbContext>(context);
        }

        public static DataRepository<TEntity> GetRespositoryTest<TEntity>(IUnitOfWorkRepository<WarehouseDbContext>  unitOfWork)
            where TEntity : class, IBaseEntity, new()
        {
            return new DataRepository<TEntity>(unitOfWork);
        }

    }
}
