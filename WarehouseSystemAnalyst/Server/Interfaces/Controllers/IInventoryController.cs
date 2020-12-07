using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Mediator.Interfaces.Base;
using WarehouseSystemAnalyst.Server.Interfaces.Base;

namespace WarehouseSystemAnalyst.Server.Interfaces.Controllers
{
    public interface IInventoryController<TRequestEntity, TResponseDto, TResponse, TRequest> :
        IBaseController<TRequestEntity, TResponseDto, TResponse, TRequest>
        where TRequestEntity : class, new()
        where TResponseDto : class, new()
        where TResponse : class, IBaseResponse<TResponseDto>, new()
        where TRequest : class, IBaseRequest<TRequestEntity, TResponseDto>, new()
    {
        Task<ActionResult<TResponse>> Change(object Id);
        Task<ActionResult<TResponse>> GetAllAsync();
        Task<ActionResult<TResponse>> DeleteAsync(object Id);
        Task<ActionResult<TResponse>> PutAsync(object Id, TResponseDto responseDto);
        Task<ActionResult<TResponse>> PostAsync(TResponseDto responseDto);
    }
}