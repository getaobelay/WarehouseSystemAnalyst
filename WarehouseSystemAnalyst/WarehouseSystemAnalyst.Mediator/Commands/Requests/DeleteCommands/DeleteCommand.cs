using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Commands.Requests
{
    /// <summary>
    /// this command deletes source and destination entities
    /// </summary>
    /// <typeparam name="TEntity">The entity to insert into the database</typeparam>
    /// <typeparam name="TDto">The source dto to map result from</typeparam>
    public class DeleteCommand<TEntity, TDto> : ICommandWrapper<TEntity>
      where TEntity : class, IBaseEntity, new()
      where TDto : class, new()
    {
        public TEntity Model { get; set; }
        public Expression<Func<TEntity, bool>> Expression { get; set; }
    }
}