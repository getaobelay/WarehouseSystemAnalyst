using MediatR;
using Microsoft.EntityFrameworkCore;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers
{
    public interface ICommandHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, ICommandResponse<TOut>>
        where TIn : ICommandWrapper<TOut>
        where TOut : class, IBaseEntity, new()
    {
        public IWarehouseContext<WarehouseDbContext, TOut> WarehouseContext { get; set; }
    }
}