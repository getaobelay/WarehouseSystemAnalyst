using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Responses
{
    public interface ITransactionResponse<TSourceDto, TDestDto>
        where TSourceDto : class, IBaseDto, new()
        where TDestDto : class, IBaseDto, new()
    {

    }
}
