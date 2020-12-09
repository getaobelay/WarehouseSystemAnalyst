using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Helpers;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace arehouseSystemAnalyst.Data.Interfaces.Repositories
{
    public interface ITransactionRepository<TSource, TDestination> : IDataRepository<TSource>
        where TSource : class, IBaseEntity, new()
        where TDestination : class, IBaseEntity, new()
    {
        Task<bool> DeleteAsync(TSource source, TDestination destination);
        Task<TransactionResponse<TSource, TDestination>> DeleteAsync(object sourceId, object destinationId);
        Task<TransactionResponse<TSource, TDestination>> InsertAsync(TSource source, TDestination destination);
        Task<TransactionResponse<TSource, TDestination>> UpdateAsync(TSource source, TDestination destination);
    }
}