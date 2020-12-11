using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Commands.Requests.CommonRequests
{
    /// <summary>
    /// this command creates source and destination entities
    /// </summary>
    /// <typeparam name="TEntity">The entity to insert into the database</typeparam>
    /// <typeparam name="TDto">The entity dto to map result from</typeparam>
    public class CreateCommandRequest<TEntity, TDto> : BaseCommandRequest<TEntity, TDto>
       where TEntity : class, IBaseEntity, new()
      where TDto : class, IBaseDto, new()
    {
        public TDto CreateObject { get; set; }
    }

}