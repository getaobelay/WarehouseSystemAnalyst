using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseSystemAnalyst.Interfaces.Repository
{
    public interface IItemQuantityRepository<TSource>
        where TSource : class, new()
    {
        Task<TSource> QuantityValidation(object productId,  object batchId, int quantity);
        Task<TSource> QuantityValidation<TDestension>(object Id, object productId, int quantity);
        Task<bool> MoveQuantity<TDestension>(TSource source, int quantityToMove)
            where TDestension : class, new();
        Task<bool> MoveQuantity<TDestension>(object productId, object batchId)
            where TDestension : class, new();
    }
}
