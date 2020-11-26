using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using WarehouseSystemAnalyst.Interfaces.CQRS.Models;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;

namespace WarehouseSystemAnalyst.Mediator.Commands.Requests
{
    public class UpdateCommand<TEntity, TDto, TContext> : ICommandWrapper<TEntity>
      where TEntity : class, new()
      where TDto : class, new()
      where TContext : DbContext, new()
    {
        public IWarehouseContext<TContext, TEntity> Context { get; set; }
        public TEntity Model { get; set; }
        public Expression<Func<TEntity, bool>> Expression { get; set; }
    }
}
