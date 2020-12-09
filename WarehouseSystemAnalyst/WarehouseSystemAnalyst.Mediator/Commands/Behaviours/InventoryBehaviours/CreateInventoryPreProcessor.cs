using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Helpers;
using WarehouseSystemAnalyst.Data.Implementation;
using WarehouseSystemAnalyst.Mediator.Commands.Requests.InventoryRequests;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Commands.Behaviours.InventoryBehaviours
{
    /// <summary>
    /// preprocessor
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <typeparam name="TSourceDto"></typeparam>
    /// <typeparam name="TDestDto"></typeparam>
    public class CreateInventoryPreProcessor<TRequest, TResponse, TSourceEntity, TSourceDto, TDestEntity, TDestDto> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : CreateInventoryCommand<TSourceEntity, TSourceDto, TDestEntity, TDestDto>
        where TResponse : TransactionResponse<TSourceDto, TDestDto>
        where TSourceEntity : class, IBaseStock, new()
        where TSourceDto : class, IBaseStockDto, new()
        where TDestEntity : class, IBaseStock, new()
        where TDestDto : class, IBaseStockDto, new()
    {
        private readonly ILogger<CreateInventoryPreProcessor<TRequest, TResponse, TSourceEntity, TSourceDto, TDestEntity, TDestDto>> _logger;
        public CreateInventoryPreProcessor(ILogger<CreateInventoryPreProcessor<TRequest, TResponse, TSourceEntity, TSourceDto, TDestEntity, TDestDto>> logger, IDataContext context)
        {
            _logger = logger ?? throw new ArgumentException(nameof(ILogger));
            repository = new TransactionRepository<TSourceEntity, TDestEntity>(context.UnitOfWork);

        }


        public TransactionRepository<TSourceEntity, TDestEntity> repository { get; }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {

            TResponse response = default;

            try
            {
                var isSourceExists = await repository.GetSingleQuery(s => s.Name == request.Name) != null;
                var isDestExists = await repository.DestRepository.GetSingleQuery(s => s.Name == request.Name) != null;

                if (isSourceExists && isDestExists)
                {
                    var errors = new List<string>() { $"{nameof(TSourceEntity)} with name {request.Name} already exists",
                    $"{nameof(TSourceEntity)} with name {request.Name} already exists" };

                    response.Destination = null;
                    response.Source = null;
                    response.ErrorMessages = errors;

                    return response;

                }

                else if (isSourceExists)
                {
                    var errors = new List<string>() { $"{nameof(TSourceEntity)} with name {request.Name} already exists" };

                    response.Destination = null;
                    response.Source = null;
                    response.ErrorMessages = errors;

                    return response;
                }

                else if (isDestExists)
                {
                    var errors = new List<string>() { $"{nameof(TDestEntity)} with name {request.Name} already exists" };
                    response.Destination = null;
                    response.Source = null;
                    response.ErrorMessages = errors;

                    return response;
                }

                else
                {
                    TSourceDto source = new TSourceDto()
                    {
                        PK = request.SourceId.ToString(),
                        Name = request.Name
                    };

                    TDestDto destination = new TDestDto()
                    {
                        PK = request.DestinationId.ToString(),
                        Name = request.Name
                    };

                    request.Source = source;
                    request.Destination = destination;

                    response = await next();

                    return response;
                }
            }

            catch (Exception e)
            {
                throw;
            }
        }

    }
}
