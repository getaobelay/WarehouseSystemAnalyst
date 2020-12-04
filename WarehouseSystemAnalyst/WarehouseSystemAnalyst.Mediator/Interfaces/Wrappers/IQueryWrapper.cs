using MediatR;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers
{
    public interface IQueryWrapper<TModel> : IRequest<IQueryResponse<TModel>>
       where TModel : class, new()
    {
        public TModel Model { get; set; }
        public IEnumerable<TModel> Models { get; set; }
        public Expression<Func<TModel, bool>> Expression { get; set; }
    }
}