using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Helpers;

namespace WarehouseSystemAnalyst.Mediator.CommonCQRS.Queries.Requests
{
    public class ListQueryRequest<TEntity, TDto> : IRequest<HandlerResponse<TDto>>
       where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
        public Expression<Func<TEntity, bool>> Filter { get; set; }
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy { get; set; }
    }
}