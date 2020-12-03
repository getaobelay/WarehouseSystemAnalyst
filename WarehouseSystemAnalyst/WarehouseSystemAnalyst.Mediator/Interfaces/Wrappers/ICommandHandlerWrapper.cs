using MediatR;
using Microsoft.EntityFrameworkCore;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Interfaces.Models;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers
{
    public interface ICommandHandlerWrapper<TIn, TOut, TContext> : IRequestHandler<TIn, ICommandResponse<TOut>>
        where TIn : ICommandWrapper<TOut>
        where TOut : class, IBaseEntity, new()
        where TContext : DbContext, new()
    {
        public IWarehouseContext<TContext, TOut> WarehouseContext { get; set; }
    }
}
