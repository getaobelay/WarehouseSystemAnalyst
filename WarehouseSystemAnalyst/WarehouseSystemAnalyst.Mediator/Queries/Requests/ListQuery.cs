using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Queries.Requests
{
    public class ListQuery<TEntity, TDto> : IQueryWrapper<TEntity>
       where TEntity : class, IBaseEntity, new()
       where TDto : class, new()
    {
        public IWarehouseContext<WarehouseDbContext, TEntity> WarehouseContext { get; set; }
        public Expression<Func<TEntity, bool>> Expression { get; set; }
        public IEnumerable<TEntity> Models { get; set; }
        public TEntity Model { get; set; }
    }
}