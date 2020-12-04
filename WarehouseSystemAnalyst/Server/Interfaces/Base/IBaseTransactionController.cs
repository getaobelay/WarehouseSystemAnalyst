using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Mediator.Interfaces.Base;

namespace WarehouseSystemAnalyst.Server.Interfaces.Base
{
    public interface IBaseTransactionController<TSourceRequest, TSourceResponse, TDestinationRequest, TDestinationResponse, TResponse, TRequest>
         where TSourceRequest : class, new()
         where TDestinationRequest : class, new()
         where TSourceResponse : class, new()
         where TDestinationResponse : class, new()
         where TResponse : class, IBaseTransactionResponse<TSourceResponse, TDestinationResponse>, new()
         where TRequest : class, IBaseTransactionRequest<TSourceRequest, TSourceResponse,TDestinationRequest,TDestinationResponse>, new()
    {
        Task<ActionResult<TResponse>> GetAsync(object sourceId, object destinationId);

        //Task<ActionResult<TResponse>> GetAsync(object Id, CancellationToken cancellationToken);
        Task<ActionResult<TResponse>> GetAllAsync();

        //Task<ActionResult<TResponse>> GetAllAsync(CancellationToken cancellationToken);
        Task<ActionResult<TResponse>> DeleteAsync(object sourceId, object destinationId);

        //Task<ActionResult<TResponse>> DeleteAsync(object Id, CancellationToken cancellationToken);
        Task<ActionResult<TResponse>> PutAsync(object sourceId, object destinationId, TSourceResponse sourceResponse, TDestinationResponse destinationResponse);

        //Task<ActionResult<TResponse>> PutAsync(object Id, TRequest entity, CancellationToken cancellationToken);
        Task<ActionResult<TResponse>> PostAsync(TSourceResponse sourceResponse, TDestinationResponse destinationResponse);

        //Task<ActionResult<TResponse>> PostAsync(TRequest entityToUpdate, CancellationToken cancellationToken);
    }
}
