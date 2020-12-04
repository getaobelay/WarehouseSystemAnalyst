using WarehouseSystemAnalyst.Mediator.Interfaces.Base;
using WarehouseSystemAnalyst.Server.Interfaces.Base;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Controllers
{
    public interface IWarehouseController<TRequestModel, TResponseModel, TResponse, TRequest> :
        IBaseController<TRequestModel, TResponseModel, TResponse, TRequest>
        where TRequestModel : class, new()
        where TResponseModel : class, new()
        where TResponse : class, IBaseResponse<TResponseModel>, new()
        where TRequest : class, IBaseRequest<TRequestModel, TResponseModel>, new()
    {
    }
}