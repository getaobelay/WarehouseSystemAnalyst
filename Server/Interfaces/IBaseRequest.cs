using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Server.BaseContollers
{
    public interface IBaseRequest<TEntity, TDto>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
        public object Id { get; set; }
    }
}