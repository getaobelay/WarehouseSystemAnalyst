using System.Collections.Generic;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Base
{
    public interface IBaseResponse<TResponseModel>
        where TResponseModel : class, new()
    {
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; }
        public TResponseModel Data { get; set; }
    }
}