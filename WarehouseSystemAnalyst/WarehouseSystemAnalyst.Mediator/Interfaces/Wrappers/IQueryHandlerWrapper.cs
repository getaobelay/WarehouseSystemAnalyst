using MediatR;
using Microsoft.EntityFrameworkCore;
using WarehouseSystemAnalyst.Mediator.Interfaces.Models;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers
{
    public interface IQueryHandlerWrapper<TIn, TOut, TContext> : IRequestHandler<TIn, IQueryResponse<TOut>>
        where TIn : IQueryWrapper<TOut>
        where TOut : class, new()
        where TContext : DbContext, new()
    {
        public IWarehouseContext<TContext, TOut> Context { get; set; }
    }
}
