using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Base;
using WarehouseSystemAnalyst.Server.Interfaces.Base;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Controllers
{
    public interface IWarehouseController<TRequestEntity, TResponseDto, TResponse, TRequest> :
        IBaseController<TRequestEntity, TResponseDto, TResponse, TRequest>
       where TRequestEntity : class, IBaseEntity, new()
        where TResponseDto : class, IBaseDto, new()
        where TResponse : class, IBaseResponse<TResponseDto>, new()
        where TRequest : class, IBaseRequest<TRequestEntity, TResponseDto>, new()
    {
        Task<ActionResult<TResponse>> MoveQuantity(object Id, object batchId, int quanity);
        Task<ActionResult<TResponse>> ReturnQuantity(object Id, object batchId, int quanity);
    }
}