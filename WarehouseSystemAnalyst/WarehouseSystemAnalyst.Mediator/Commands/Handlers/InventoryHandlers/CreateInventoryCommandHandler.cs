using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Helpers;
using WarehouseSystemAnalyst.Data.Implementation;
using WarehouseSystemAnalyst.Mediator.Commands.Requests.InventoryRequests;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Commands.Handlers.InventoryHandlers
{
    public class CreateInventoryCommandHandler<TSourceEntity, TSourceDto, TDestEntity, TDestDto, TCommand> : IRequestHandler<TCommand, TransactionResponse<TSourceDto, TDestDto>>
        where TSourceEntity : class, IBaseStock, new()
        where TSourceDto : class, IBaseStockDto, new()
        where TDestEntity : class, IBaseStock, new()
        where TDestDto : class, IBaseStockDto, new()
        where TCommand : CreateInventoryCommand<TSourceEntity, TSourceDto, TDestEntity, TDestDto>, new()
    {
        public CreateInventoryCommandHandler(TransactionRepository<TSourceEntity, TDestEntity> stockRepository)
        {
            StockRepository = stockRepository;
        }

        public TransactionRepository<TSourceEntity, TDestEntity> StockRepository { get; }

        public async Task<TransactionResponse<TSourceDto, TDestDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            if (request.Source == null && request.Destination == null)
                throw new ArgumentNullException($"{nameof(request.Source)} && {nameof(request.Destination) }");

            if (request.UpdateDestination)
            {
                var createdSource = MappingHelper.Mapper.Map<TSourceEntity>(request.Source);
                var createdDest = MappingHelper.Mapper.Map<TDestEntity>(request.Destination);

                var result = await StockRepository.InsertAsync(createdSource, createdDest);

                if (result.Source != null & result.Destination != null)
                {
                    var mappedSourceObject = MappingHelper.Mapper.Map<TSourceDto>(result.Source);
                    var mappedDestObject = MappingHelper.Mapper.Map<TDestDto>(result.Destination);

                    return TransactionResponse.Success(mappedSourceObject, mappedDestObject);
                }

                return TransactionResponse.Error<TSourceDto, TDestDto>(result.ErrorMessages);
            }

            else
            {

                var createdSource = MappingHelper.Mapper.Map<TSourceEntity>(request.Source);
                var result = await StockRepository.InsertAsync(createdSource);

                if (result != null)
                {
                    var mappedSourceObject = MappingHelper.Mapper.Map<TSourceDto>(result);
                    return TransactionResponse.Success<TSourceDto, TDestDto>(mappedSourceObject, default);
                }

                return TransactionResponse.Error<TSourceDto, TDestDto>(new List<string>() { "Failed to create" });
            }


        }
    }
}
