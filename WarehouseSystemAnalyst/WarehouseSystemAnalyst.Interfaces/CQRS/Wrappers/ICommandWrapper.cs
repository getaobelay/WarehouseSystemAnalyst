using MediatR;
using System;
using System.Linq.Expressions;
using WarehouseSystemAnalyst.Interfaces.CQRS.Models;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers
{
    public interface ICommandWrapper<TModel> : IRequest<ICommandResponse<TModel>>
        where TModel : class, new()
    {
        public TModel Model { get; set; }
        public Expression<Func<TModel, bool>> Expression { get; set; }

    }
}
