using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Interfaces.Base;

namespace WarehouseSystemAnalyst.Interfaces.Controllers
{
    public interface IItemQuantityController<TRequestModel, TResponseModel, TResponse, TRequest> :
        IBaseController<TRequestModel, TResponseModel, TResponse, TRequest>
        where TRequestModel : class, new()
        where TResponseModel : class, new()
        where TResponse : class, IBaseResponse<TResponseModel>, new()
        where TRequest : class, IBaseRequest<TRequestModel, TResponseModel>, new()
    {

    }
}
