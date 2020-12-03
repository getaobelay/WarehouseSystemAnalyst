using WarehouseSystemAnalyst.Mediator.Interfaces.Base;

namespace WarehouseSystemAnalyst.Interfaces.Responses
{
    public interface IWarehouseResponse<TResponseModel> :
        IBaseResponse<TResponseModel>
        where TResponseModel : class, new()
    {
    }
}
