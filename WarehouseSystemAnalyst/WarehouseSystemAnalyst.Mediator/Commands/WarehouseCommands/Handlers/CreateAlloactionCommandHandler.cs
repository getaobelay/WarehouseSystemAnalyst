using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Commands.WarehouseCommands.Requests;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Commands.WarehouseCommands.Handlers
{
    public class CreateAlloactionCommandHandler<TEntity, TDto, TCommand> : IRequestHandler<TCommand, ICommandResponse<TDto>>
        where TEntity : class, IBaseWarehouse, new()
        where TDto : class, IBaseWarehouseDto, new()
        where TCommand : AllocationCommand<TEntity, TDto>, new()
    {
        public Task<ICommandResponse<TDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}