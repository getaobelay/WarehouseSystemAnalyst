using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Commands.StockCommands.Requests;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Commands.StockCommands.Handlers
{
    public class ReturnQuantityCommandHandler<TEntity, TDto, TCommand> : IRequestHandler<TCommand, ICommandResponse<TDto>>
        where TEntity : class, IBaseStock, new()
        where TDto : BaseDto, new()
        where TCommand : QuantityCommandRequest<TEntity, TDto>, new()
    {
        public Task<ICommandResponse<TDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}