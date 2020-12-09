using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Helpers;
using WarehouseSystemAnalyst.Data.Implementation;
using WarehouseSystemAnalyst.Mediator.Commands.Requests.InventoryRequests;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Mapping;

namespace WarehouseSystemAnalyst.Mediator.Commands.Handlers.WarehouseHandlers
{
    public class UpdateInventoryCommandHandler<TSourceEntity, TSourceDto, TDestEntity, TDestDto, TCommand> : IRequestHandler<TCommand, TransactionResponse<TSourceDto, TDestDto>>
        where TSourceEntity : class, IBaseStock, new()
        where TSourceDto : class, IBaseStockDto, new()
        where TDestEntity : class, IBaseStock, new()
        where TDestDto : class, IBaseStockDto, new()
        where TCommand : UpdateInventoryCommand<TSourceEntity, TSourceDto, TDestEntity, TDestDto>, new()
    {
        public UpdateInventoryCommandHandler(TransactionRepository<TSourceEntity, TDestEntity> stockRepository)
        {
            StockRepository = stockRepository;
        }

        public TransactionRepository<TSourceEntity, TDestEntity> StockRepository { get; }

        public async Task<TransactionResponse<TSourceDto, TDestDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {

            var source = await StockRepository.GetSingleQuery(s => s.PK == request.SourceId.ToString());
            var destination = await StockRepository.DestRepository.GetSingleQuery(s => s.PK == request.DestinationId.ToString());

            if (source == null && destination == null)
            {
                var errors = new List<string>() { $"{nameof(TSourceEntity)} with name {request.SourceId} doesn't exists",
                    $"{nameof(TSourceEntity)} with name {request.DestinationId} doesn't exists" };

                return await Task.FromResult(TransactionResponse.Error<TSourceDto, TDestDto>(errors));

            }

            else if (source == null)
            {
                var errors = new List<string>() { $"{nameof(TSourceEntity)} with name {request.SourceId} doesn't exists" };
                return await Task.FromResult(TransactionResponse.Error<TSourceDto, TDestDto>(errors));
            }

            else if (destination == null)
            {
                var errors = new List<string>() { $"{nameof(TDestEntity)} with name {request.DestinationId} doesn't exists" };

                return await Task.FromResult(TransactionResponse.Error<TSourceDto, TDestDto>(errors));
            }

            source.ProductQuantity -= request.Quantity;
            source.BatchQuantity -= request.Quantity;
            destination.ProductQuantity += request.Quantity;
            destination.BatchQuantity += request.Quantity;

            var result = await StockRepository.UpdateAsync(source, destination);

            if (result.Source != null & result.Destination != null)
            {
                var mappedSourceObject = MappingHelper.Mapper.Map<TSourceDto>(result.Source);
                var mappedDestObject = MappingHelper.Mapper.Map<TDestDto>(result.Destination);

                return TransactionResponse.Success(mappedSourceObject, mappedDestObject);
            }

            return await Task.FromResult(TransactionResponse.Error<TSourceDto, TDestDto>(new List<string>() { "Failed to update" }));
        }
    }
}