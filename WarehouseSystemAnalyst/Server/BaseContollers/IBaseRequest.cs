using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Server.BaseContollers
{
    public interface IBaseRequest<TRequestEntity, TResponseDto>
        where TRequestEntity : class, IBaseEntity, new()
        where TResponseDto : class, IBaseDto, new()
    {
    }
}