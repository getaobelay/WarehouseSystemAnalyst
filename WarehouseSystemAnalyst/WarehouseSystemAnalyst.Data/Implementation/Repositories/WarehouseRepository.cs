using System;
using System.Collections.Generic;
using System.Text;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Implementation.BaseRepositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using arehouseSystemAnalyst.Data.Interfaces.Repositories;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Helpers.Repositories;
using System.Linq.Expressions;
using System.Linq;

namespace WarehouseSystemAnalyst.Data.Implementation.Repositories
{
    public class WarehouseRepository<TSource, TDestension> :
        BaseTransactionRepository<TSource, TDestension>, IWarehouseRepository<TSource, TDestension>
        where TSource : class, IBaseWarehouse<WarehouseItem>, new()
        where TDestension : class, IBaseWarehouse<WarehouseItem>, new()
    {
        protected WarehouseRepository(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork) : base(unitOfWork)
        {
        }

        public WarehouseRepository(WarehouseDbContext context) : base(context)
        {
        }

    }
}
