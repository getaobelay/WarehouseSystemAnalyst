﻿using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Helpers;
using WarehouseSystemAnalyst.Data.Implementation;
using WarehouseSystemAnalyst.Mediator.Commands.Requests.CommonRequests;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Commands.Handlers.CommonHandlers
{
    public class DeleteTransactionCommandHandler<TSourceEntity, TSourceDto, TDestEntity, TDestDto, TCommand> : IRequestHandler<TCommand, TransactionResponse<TSourceDto, TDestDto>>
        where TSourceEntity : class, IBaseStock, new()
        where TSourceDto : class, IBaseStockDto, new()
        where TDestEntity : class, IBaseStock, new()
        where TDestDto : class, IBaseStockDto, new()
        where TCommand : DeleteTransctionCommandRequest<TSourceEntity, TSourceDto, TDestEntity, TDestDto>, new()
    {
        public DeleteTransactionCommandHandler(TransactionRepository<TSourceEntity, TDestEntity> stockRepository)
        {
            StockRepository = stockRepository;
        }

        public TransactionRepository<TSourceEntity, TDestEntity> StockRepository { get; }

        public async Task<TransactionResponse<TSourceDto, TDestDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            if (request.UpdateDestination)
            {
                var result = await StockRepository.DeleteAsync(request.SourceId, request.DestinationId);

                if (result.ErrorMessages != null)
                {
                    return TransactionResponse.Success<TSourceDto, TDestDto>(default, default);
                }

                return TransactionResponse.Error<TSourceDto, TDestDto>(result.ErrorMessages);
            }

            else
            {
                var result = await StockRepository.DeleteAsync(request.SourceId);

                if (result)
                {
                    return TransactionResponse.Success<TSourceDto, TDestDto>(default, default);
                }

                return await Task.FromResult(TransactionResponse.Error<TSourceDto, TDestDto>(new List<string>() { "Failed to Delete" }));

            }
        }
    }
}