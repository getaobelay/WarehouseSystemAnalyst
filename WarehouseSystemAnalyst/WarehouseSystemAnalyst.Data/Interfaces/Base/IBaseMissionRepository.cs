using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Interfaces.Base;
using WarehouseSystemAnalyst.Data.Interfaces.Models;

namespace WarehouseSystemAnalyst.Data.Interfaces.Repositories
{
    /// <summary>
    /// destination
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestension"></typeparam>
    public interface IBaseMissionRepository<TSourceEntity, TDestinationEntity> : IQueryRepository<TSourceEntity>
        where TSourceEntity : IBaseEntity, new()
        where TDestinationEntity : IBaseEntity, new()
    {
        Task<bool> Push<TSource, TDestination>(object missionId)
                    where TSource : class, new()
                    where TDestination : class, new();

        Task<bool> Pop<TSource, TDestination>(object missionId)
                   where TSource : class, new()
                   where TDestination : class, new();

        Task<bool> ChangeStatus<TSource, TDestination>(TSource source, TDestination destination)
                where TSource : class, new()
                where TDestination : class, new();

        Task<bool> ChangeStatus<TSource, TDestination>(object missionId)
                    where TSource : class, new()
                    where TDestination : class, new();

        Task<bool> Move<TSource, TDestination>(object missionId, int quantity)
                   where TSource : class, new()
                   where TDestination : class, new();

        Task<bool> Complete<TSource, TDestination>(object missionId, int quantity)
                    where TSource : class, new()
                    where TDestination : class, new();
    }
}
