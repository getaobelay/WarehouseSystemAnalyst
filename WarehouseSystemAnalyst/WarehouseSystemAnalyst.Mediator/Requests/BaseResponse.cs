using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Interfaces.Base;

namespace WarehouseSystemAnalyst.Mediator.Requests
{
    public class BaseResponse<TResponseModel> : IBaseResponse<TResponseModel>
        where TResponseModel : class, new()
    {
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; }
        public TResponseModel Data { get; set; }
    }
}
