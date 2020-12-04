using MediatR;
using Microsoft.EntityFrameworkCore;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers
{
    public interface IQueryHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, IQueryResponse<TOut>>
        where TIn : IQueryWrapper<TOut>
        where TOut : class, IBaseEntity, new()
    {
        public IWarehouseContext<WarehouseDbContext, TOut> WarehouseContext { get; set; }
    }
}