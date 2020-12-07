using WarehouseSystemAnalyst.Mediator.Interfaces.Base;
using WarehouseSystemAnalyst.Server.Interfaces.Base;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Controllers
{
    public interface IWarehouseController<TRequestEntity, TResponseDto, TResponse, TRequest> :
        IBaseController<TRequestEntity, TResponseDto, TResponse, TRequest>
        where TRequestEntity : class, new()
        where TResponseDto : class, new()
        where TResponse : class, IBaseResponse<TResponseDto>, new()
        where TRequest : class, IBaseRequest<TRequestEntity, TResponseDto>, new()
    {
    }
}