using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Commands.Responses.CommonResponses
{
    public interface ICommandResponse<TDto>
        where TDto : class, IBaseDto, new()
    {
    }
}
