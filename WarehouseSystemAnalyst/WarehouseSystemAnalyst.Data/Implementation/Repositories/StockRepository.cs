using arehouseSystemAnalyst.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.Data.DataContext;

namespace WarehouseSystemAnalyst.Data.Implementation.Repositories
{
    public class StockRepository<TEntity> : DataRepository<TEntity>, IStockRepository<TEntity>
        where TEntity : class, IBaseStock, new()
    {
        public StockRepository(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork) : base(unitOfWork)
        {
        }

        public StockRepository(WarehouseDbContext context) : base(context)
        {
        }

        public async Task<TEntity> ReturnAlloactionItem(object Id, WarehouseItem warehouseItems)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> ReturnWarehouseItem(object Id, WarehouseItem warehouseItems)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAlloaction(object Id, Allocation allocation)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateWarehouseItem(object Id, WarehouseItem item)
        {
            throw new NotImplementedException();
        }
    }
}
