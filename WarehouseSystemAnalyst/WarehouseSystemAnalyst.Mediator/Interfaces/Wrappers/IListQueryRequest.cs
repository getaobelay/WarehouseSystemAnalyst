using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers
{
    public interface IListQueryRequest<TEntity, TDto> : IRequest<IListQueryResponse<TDto>>
       where TEntity : class, IBaseEntity, new()
       where TDto : BaseDto, new()
    {
        public Expression<Func<TEntity, bool>> Filter { get; set; }
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy { get; set; }
    }
}