using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Requests
{
    /// <summary>
    /// this command deletes source and destination entities
    /// </summary>
    /// <typeparam name="TEntity">The entity to insert into the database</typeparam>
    /// <typeparam name="TDto">The source dto to map result from</typeparam>
    public class DeleteCommandRequest<TEntity, TDto> : BaseCommandRequest<TEntity, TDto>
      where TEntity : class, IBaseEntity, new()
      where TDto : class, IBaseDto, new()
    {
        public object Id { get; set; }
    }
}