using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Base
{
    public interface IBaseRequest<TRequestEntity, TResponseDto>
        where TRequestEntity : class, IBaseEntity, new()
        where TResponseDto : class, IBaseDto, new()
    {
        public object Id { get; set; }
    }
}