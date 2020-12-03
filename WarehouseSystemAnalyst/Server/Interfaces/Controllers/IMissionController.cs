using System;
using System.Collections.Generic;
using System.Text;
using WarehouseSystemAnalyst.Mediator.Interfaces.Base;
using WarehouseSystemAnalyst.Server.Interfaces.Base;

namespace WarehouseSystemAnalyst.Server.Interfaces.Controllers
{
    public interface IMissionController<TRequestModel, TResponseModel, TResponse, TRequest> :
        IBaseController<TRequestModel, TResponseModel, TResponse, TRequest>
        where TRequestModel : class, new()
        where TResponseModel : class, new()
        where TResponse : class, IBaseResponse<TResponseModel>, new()
        where TRequest : class, IBaseRequest<TRequestModel, TResponseModel>, new()
    {
    }
}
