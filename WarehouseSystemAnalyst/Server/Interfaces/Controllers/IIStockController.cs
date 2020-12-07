using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Interfaces.Base;
using WarehouseSystemAnalyst.Mediator.Requests;
using WarehouseSystemAnalyst.Server.Interfaces.Base;

namespace WarehouseSystemAnalyst.Server.Interfaces.Controllers
{
    public interface IIStockController<TRequestEntity, TResponseDto, TResponse, TRequest> :
        IBaseController<TRequestEntity, TResponseDto, TResponse, TRequest>
        where TRequestEntity : class, new()
        where TResponseDto : class, new()
        where TResponse : class, IBaseResponse<TResponseDto>, new()
        where TRequest : class, IBaseRequest<TRequestEntity, TResponseDto>, new()
    {
        Task<ActionResult<TResponse>> UpdateAllocatedQuanityAsync(object Id, int quanity);
        Task<ActionResult<TResponse>> ReturnAllocatedQuanityAsync(object Id, int quanity);
        Task<ActionResult<TResponse>> UpdateAlloaction(object Id);
    }
}