using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;
using WarehouseSystemAnalyst.Data.Implementation.BaseRepositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Containers;
using WarehouseSystemAnalyst.Mediator.Helpers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Base;
using WarehouseSystemAnalyst.Server.Interfaces.Base;

namespace WarehouseSystemAnalyst.Server.BaseContollers
{
    public class BaseTransactionController<TSourceRequest, TSourceResponse, TDestinationRequest, TDestinationResponse, TResponse, TRequest> : ControllerBase,
            IBaseTransactionController<TSourceRequest, TSourceResponse, TDestinationRequest, TDestinationResponse, TResponse, TRequest>
         where TSourceRequest : class, new()
         where TDestinationRequest : class, new()
         where TSourceResponse : class, new()
         where TDestinationResponse : class, new()
         where TResponse : class, IBaseTransactionResponse<TSourceResponse, TDestinationResponse>, new()
         where TRequest : class, IBaseTransactionRequest<TSourceRequest, TSourceResponse, TDestinationRequest, TDestinationResponse>, new()
    {
        private IMediator mediator;
        protected BaseTransactionController() => mediator = MediatorContainer.BuildMediator();

        public IMediator Mediator { get { return mediator; } }
        public Task<ActionResult<TResponse>> DeleteAsync(object sourceId, object destinationId)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<TResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<TResponse>> GetAsync(object sourceId, object destinationId)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<TResponse>> PostAsync(TSourceResponse sourceResponse, TDestinationResponse destinationResponse)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<TResponse>> PutAsync(object sourceId, object destinationId, TSourceResponse sourceResponse, TDestinationResponse destinationResponse)
        {
            throw new NotImplementedException();
        }
    }
}