using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WarehouseSystemAnalyst.Interfaces.Base
{
    public interface IBaseController<TRequestModel, TResponseModel, TResponse, TRequest>
        where TRequestModel : class, new()
        where TResponseModel : class, new()
        where TResponse : class, IBaseResponse<TResponseModel>, new()
        where TRequest : class, IBaseRequest<TRequestModel, TResponseModel>, new()
    {
        Task<ActionResult<TResponse>> GetAsync(object Id);
        //Task<ActionResult<TResponse>> GetAsync(object Id, CancellationToken cancellationToken);
        Task<ActionResult<TResponse>> GetAllAsync();
        //Task<ActionResult<TResponse>> GetAllAsync(CancellationToken cancellationToken);
        Task<ActionResult<TResponse>> DeleteAsync(object Id);
        //Task<ActionResult<TResponse>> DeleteAsync(object Id, CancellationToken cancellationToken);
        Task<ActionResult<TResponse>> PutAsync(object Id, TResponseModel entity);
        //Task<ActionResult<TResponse>> PutAsync(object Id, TRequest entity, CancellationToken cancellationToken);
        Task<ActionResult<TResponse>> PostAsync(TResponseModel entityToUpdate);
        //Task<ActionResult<TResponse>> PostAsync(TRequest entityToUpdate, CancellationToken cancellationToken);

    }
}
