using System;
using System.Collections.Generic;
using System.Text;
using WarehouseSystemAnalyst.Interfaces.Base;

namespace WarehouseSystemAnalyst.Services.Base
{
    public class BaseRequest<TRequestModel, TResponseModel> : IBaseRequest<TRequestModel, TResponseModel>
        where TRequestModel : class, new()
        where TResponseModel : class, new()
    {
        public object Id { get; set; }
        public List<string> ErrorMessages { get; set; }
        public TResponseModel Data { get; set; }
    }
}
