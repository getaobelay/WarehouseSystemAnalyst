using System;
using System.Collections.Generic;
using System.Text;
using WarehouseSystemAnalyst.Mediator.Interfaces.Base;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Requests
{
    public interface IProductRequest<TRequestModel, TResponseModel> :
        IBaseRequest<TRequestModel, TResponseModel>
        where TResponseModel : class, new()
        where TRequestModel : class, new()
    {

    }
}
