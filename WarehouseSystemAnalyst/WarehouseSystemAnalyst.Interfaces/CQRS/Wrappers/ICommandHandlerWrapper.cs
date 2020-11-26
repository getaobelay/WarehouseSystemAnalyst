using MediatR;
using Microsoft.EntityFrameworkCore;
using WarehouseSystemAnalyst.Interfaces.CQRS.Models;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers
{
    public interface ICommandHandlerWrapper<TIn, TOut, TContext> : IRequestHandler<TIn, ICommandResponse<TOut>>
        where TIn : ICommandWrapper<TOut>
        where TOut : class, new()
        where TContext : DbContext, new()
    {
        public IWarehouseContext<TContext, TOut> Context { get; set; }
    }
}
