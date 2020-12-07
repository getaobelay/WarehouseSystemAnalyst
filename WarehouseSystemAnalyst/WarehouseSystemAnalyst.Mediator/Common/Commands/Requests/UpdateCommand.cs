using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Commands.Requests
{
    /// <summary>
    /// this command creates source and destination entities
    /// </summary>
    /// <typeparam name="TEntity">The entity to insert into the database</typeparam>
    /// <typeparam name="TDto">The source dto to map result from</typeparam>
    public class UpdateCommand<TEntity, TDto> : ICommandRequest<TEntity, TDto>
      where TEntity : class, IBaseEntity, new()
      where TDto : BaseDto, new()
    {
        public object Id { get; set; }
        public TEntity Entity { get; set; }
    }
}