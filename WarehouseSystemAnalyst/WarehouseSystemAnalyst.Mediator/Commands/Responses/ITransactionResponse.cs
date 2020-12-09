using MediatR;
using WarehouseSystemAnalyst.Data.Helpers;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Commands.Requests
{
    public interface ITransactionResponse<TSourceDto ,TDestDto>
        where TSourceDto : class, IBaseDto, new()
        where TDestDto : class, IBaseDto, new()
    {

    }
}
