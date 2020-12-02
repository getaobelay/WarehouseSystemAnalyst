using System.Collections.Generic;
using WarehouseSystemAnalyst.Interfaces.Base;

namespace WarehouseSystemAnalyst.Data.Implementation.BaseApi
{
    public class BaseResponse<TResponseModel> : IBaseResponse<TResponseModel>
        where TResponseModel : class, new()
    {
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; }
        public TResponseModel Data { get; set; }
    }
}
