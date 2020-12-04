using MediatR;
using System;
using System.Linq.Expressions;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers
{
    public interface ICommandWrapper<TModel> : IRequest<ICommandResponse<TModel>>
        where TModel : class, IBaseEntity, new()
    {
        public TModel Model { get; set; }
        public Expression<Func<TModel, bool>> Expression { get; set; }
    }
}