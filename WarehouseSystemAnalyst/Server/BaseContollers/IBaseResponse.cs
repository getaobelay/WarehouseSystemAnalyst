using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Server.BaseContollers
{
    public interface IBaseResponse<TResponseDto> where TResponseDto : class, IBaseDto, new()
    {
    }
}