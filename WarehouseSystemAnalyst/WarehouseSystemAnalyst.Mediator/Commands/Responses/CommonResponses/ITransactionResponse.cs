using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Commands.Responses.CommonResponses
{
    public interface ITransactionResponse<TSourceDto, TDestDto>
        where TSourceDto : class, IBaseDto, new()
        where TDestDto : class, IBaseDto, new()
    {

    }
}
