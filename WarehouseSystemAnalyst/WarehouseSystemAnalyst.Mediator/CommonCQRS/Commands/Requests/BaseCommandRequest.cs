using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Requests
{
    public abstract class BaseCommandRequest<TEntity, TDto> : ICommandRequest<TEntity, TDto>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
    }

}
