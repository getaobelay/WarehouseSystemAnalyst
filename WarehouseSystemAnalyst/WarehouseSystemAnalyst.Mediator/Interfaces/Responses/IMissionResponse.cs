using WarehouseSystemAnalyst.Mediator.Interfaces.Base;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Responses
{
    public interface IMissionResponse<TResponseModel> :
        IBaseResponse<TResponseModel>
        where TResponseModel : class, new()
    {

    }

}
