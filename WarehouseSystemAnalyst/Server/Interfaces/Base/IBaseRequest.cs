using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Server.Interfaces.Base
{
    public interface IBaseRequest<TRequestEntity, TResponseDto>
        where TRequestEntity : class, IBaseEntity, new()
        where TResponseDto : class, IBaseDto, new()
    {
    }
}