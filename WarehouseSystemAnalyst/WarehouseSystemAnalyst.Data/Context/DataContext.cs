using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Data.Context
{
    public class DataContext<TEntity> : IDataContext<WarehouseDbContext, TEntity>
        where TEntity : class, IBaseEntity, new()
    {
        public DataContext(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        public IUnitOfWorkRepository<WarehouseDbContext> UnitOfWork { get; set; }
    }
}
