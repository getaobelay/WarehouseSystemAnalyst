using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Base
{
    public interface IBaseRequest<TRequestModel, TResponseModel>
        where TResponseModel : class, new()
        where TRequestModel : class, new()
    {
        public object Id { get; set; }
        public TResponseModel Data { get; set; }
    }
}
