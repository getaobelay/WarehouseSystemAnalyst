using arehouseSystemAnalyst.Data.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Helpers;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Commands.StockCommands.Requests;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Helpers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Commands.StockCommands.Handlers
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
            var isSourceExists = await StockRepository.GetSingleQuery(s => s.Name == request.Name) != null;
            var isDestExists = await StockRepository.DestRepository.GetSingleQuery(s => s.Name == request.Name) != null;

            if (isSourceExists && isDestExists)
            {
                var errors = new List<string>() { $"{nameof(TSourceEntity)} with name {request.Name} already exists",
                    $"{nameof(TSourceEntity)} with name {request.Name} already exists" };

                return await Task.FromResult(TransactionResponse.Error<TSourceDto, TDestDto>(errors));

            }

            else if (isSourceExists)
            {
                var errors = new List<string>() { $"{nameof(TSourceEntity)} with name {request.Name} already exists" };
                return await Task.FromResult(TransactionResponse.Error<TSourceDto, TDestDto>(errors));
            }

            else if (isDestExists)
            {
                var errors = new List<string>() { $"{nameof(TDestEntity)} with name {request.Name} already exists" };

                return await Task.FromResult(TransactionResponse.Error<TSourceDto, TDestDto>(errors));
            }

            TSourceEntity source = new TSourceEntity()
            {
                PK = request.SourceId.ToString(),
                Name = request.Name
            };

            TDestEntity destination = new TDestEntity()
            {
                PK = request.DestinationId.ToString(),
                Name = request.Name
            };

            var result = await StockRepository.InsertAsync(source, destination);

            if (result.source != null & result.Destination != null)
            {
                var mappedSourceObject = MappingHelper.Mapper.Map<TSourceDto>(result.source);
                var mappedDestObject = MappingHelper.Mapper.Map<TDestDto>(result.Destination);

                return TransactionResponse.Success(mappedSourceObject, mappedDestObject);
            }

            return TransactionResponse.Error<TSourceDto, TDestDto>(result.ErrorMessages);

        }
    }
}
