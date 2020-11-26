using System;
using System.Collections.Generic;
using System.Text;
using WarehouseSystemAnalyst.Interfaces.Base;

namespace WarehouseSystemAnalyst.Services.Base
{
    public class BaseResponse<TResponseModel> : IBaseResponse<TResponseModel>
        where TResponseModel : class, new()
    {
        public bool Success { get; set; }
        public List<string> ErrorMessages {get;set;}
        public TResponseModel Data { get; set; }
    }
}
