using arehouseSystemAnalyst.Data.Interfaces.Repositories;
using System;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Helpers.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace WarehouseSystemAnalyst.Data.Implementation.Repositories
{

    public class WarehouseRepository<TEntity> : DataRepository<TEntity>, IWarehouseRepository<TEntity>
       where TEntity : class, IBaseWarehouse, new()
    {
        public WarehouseRepository(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork) : base(unitOfWork)
        {
        }

        public WarehouseRepository(WarehouseDbContext context) : base(context)
        {
        }

        public Task<TEntity> MoveWarehouseItem(object Id, WarehouseItem item)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> ReturnAlloactionItem(object Id, WarehouseItem warehouseItems)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> ReturnWarehouseItem(object Id, WarehouseItem item)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAlloaction(object Id, Allocation allocation)
        {
            throw new NotImplementedException();
        }
    }
}