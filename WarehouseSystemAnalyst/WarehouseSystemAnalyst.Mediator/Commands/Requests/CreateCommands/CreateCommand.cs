using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Commands.Requests.CreateCommands
{
    /// <summary>
    /// this command creates source and destination entities
    /// </summary>
    /// <typeparam name="TEntity">The entity to insert into the database</typeparam>
    /// <typeparam name="TDto">The entity dto to map result from</typeparam>
    public class CreateCommand<TEntity, TDto> : ICommandWrapper<TEntity>
       where TEntity : class, IBaseEntity, new()
       where TDto : class, new()
    {
        public IWarehouseContext<WarehouseDbContext, TEntity> WarehouseContext { get; set; }
        public TEntity Model { get; set; }
        public Expression<Func<TEntity, bool>> Expression { get; set; }
    }
}