using System;
using System.Linq;
using System.Linq.Expressions;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Wrappers;

namespace WarehouseSystemAnalyst.Mediator.Common.Queries.Requests
{
    public class SingleQuery<TEntity, TDto> : IQueryRequest<TEntity, TDto>
        where TEntity : class, IBaseEntity, new()
        where TDto : BaseDto, new()
    {
        public object Id { get; set; }
        public Expression<Func<TEntity, bool>> Filter { get; set; }
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy { get; set; }
    }
}