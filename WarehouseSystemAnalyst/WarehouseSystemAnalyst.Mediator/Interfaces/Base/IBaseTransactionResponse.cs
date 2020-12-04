using System.Collections.Generic;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Base
{
    public interface IBaseTransactionResponse<TSource, TDestination>
        where TSource : class, new()
        where TDestination : class, new()
    {
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; }
        public TSource Data { get; set; }
    }
}