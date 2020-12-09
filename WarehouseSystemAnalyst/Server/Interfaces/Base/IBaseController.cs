using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Server.Interfaces.Base
{

    public interface IBaseController<TRequestEntity, TResponseDto, TResponse, TRequest>
         where TRequestEntity : class,IBaseEntity, new()
         where TResponseDto : class,IBaseDto, new()
         where TResponse : class, IBaseResponse<TResponseDto>, new()
         where TRequest : class, IBaseRequest<TRequestEntity, TResponseDto>, new()
    {
        Task<ActionResult<TResponse>> GetAsync(object Id);

        //Task<ActionResult<TResponse>> GetAsync(object Id, CancellationToken cancellationToken);
        Task<ActionResult<TResponse>> GetAllAsync();

        //Task<ActionResult<TResponse>> GetAllAsync(CancellationToken cancellationToken);
        Task<ActionResult<TResponse>> DeleteAsync(object Id);

        //Task<ActionResult<TResponse>> DeleteAsync(object Id, CancellationToken cancellationToken);
        Task<ActionResult<TResponse>> PutAsync(object Id, TResponseDto responseDto);

        //Task<ActionResult<TResponse>> PutAsync(object Id, TRequest entity, CancellationToken cancellationToken);
        Task<ActionResult<TResponse>> PostAsync(TResponseDto responseDto);

        //Task<ActionResult<TResponse>> PostAsync(TRequest entityToUpdate, CancellationToken cancellationToken);
    }
}