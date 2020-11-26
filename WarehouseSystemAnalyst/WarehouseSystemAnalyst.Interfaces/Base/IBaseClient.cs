using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseSystemAnalyst.Interfaces.Base
{
    public interface IBaseClient<TResponseModel, TRequstModel, TRequest, TResponse> : IBaseRepository<TResponseModel>
        where TResponseModel : class, new()
        where TRequstModel : class, new()
        where TRequest : class, IBaseRequest<TRequstModel, TResponseModel>, new()
        where TResponse : class, IBaseResponse<TResponseModel>, new()
    {
    }
}
