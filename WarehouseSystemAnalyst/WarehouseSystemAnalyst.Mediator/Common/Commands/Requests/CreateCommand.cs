using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Commands.Requests.CreateCommands
{
    /// <summary>
    /// this command creates source and destination entities
    /// </summary>
    /// <typeparam name="TEntity">The entity to insert into the database</typeparam>
    /// <typeparam name="TDto">The entity dto to map result from</typeparam>
    public class CreateCommand<TEntity, TDto> : ICommandRequest<TEntity, TDto>
       where TEntity : class, IBaseEntity, new()
      where TDto : BaseDto, new()
    {
        public IDataContext<WarehouseDbContext, TEntity> Context { get; set; }
        public TEntity Entity { get; set; }
        public object Id { get; set; }
    }
}