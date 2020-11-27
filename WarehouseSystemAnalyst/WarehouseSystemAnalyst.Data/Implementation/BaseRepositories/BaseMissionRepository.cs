using System;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Implementation.BaseRepositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace WarehouseSystemAnalyst.Data.Implementation.Repositories
{
    public abstract class BaseMissionRepository<TSourceEntity, TDestensionEntity> :
        BaseRepository<TSourceEntity>,
        IBaseMissionRepository<TSourceEntity, TDestensionEntity>
        where TSourceEntity : class, IBaseStock, new()
        where TDestensionEntity : class, IBaseStock, new()
    {
        protected BaseMissionRepository(Context.WarehouseDbContext context) : base(context)
        {
        }

        public Task<bool> ChangeStatus<TSource, TDestination>(TSource source, TDestination destination)
            where TSource : class, new()
            where TDestination : class, new()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ChangeStatus<TSource, TDestination>(object missionId)
            where TSource : class, new()
            where TDestination : class, new()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Complete<TSource, TDestination>(object missionId, int quantity)
            where TSource : class, new()
            where TDestination : class, new()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Move<TSource, TDestination>(object missionId, int quantity)
            where TSource : class, new()
            where TDestination : class, new()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Pop<TSource, TDestination>(object missionId)
            where TSource : class, new()
            where TDestination : class, new()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Push<TSource, TDestination>(object missionId)
            where TSource : class, new()
            where TDestination : class, new()
        {
            throw new NotImplementedException();
        }
    }
}
