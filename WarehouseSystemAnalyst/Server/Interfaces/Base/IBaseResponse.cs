using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Server.Interfaces.Base
{
    public interface IBaseResponse<TResponseDto> where TResponseDto : class, IBaseDto, new()
    {
    }
}