using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Base;
using WarehouseSystemAnalyst.Server.Interfaces.Base;

namespace WarehouseSystemAnalyst.Server.Interfaces.Controllers
{
    /// <summary>
    /// validation
    /// </summary>
    /// <typeparam name="TRequestEntity"></typeparam>
    /// <typeparam name="TResponseDto"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TRequest"></typeparam>
    public interface IIStockController<TRequestEntity, TResponseDto, TResponse, TRequest> :
        IBaseController<TRequestEntity, TResponseDto, TResponse, TRequest>
        where TRequestEntity : class, IBaseEntity, new()
        where TResponseDto : class, IBaseDto, new()
        where TResponse : class, IBaseResponse<TResponseDto>, new()
        where TRequest : class, IBaseRequest<TRequestEntity, TResponseDto>, new()
    {
        Task<ActionResult<TResponse>> UpdateAllocatedQuanityAsync(object Id, int quanity);
        Task<ActionResult<TResponse>> ReturnAllocatedQuanityAsync(object Id, int quanity);
        Task<ActionResult<TResponse>> UpdateAlloaction(object Id);
    }
}