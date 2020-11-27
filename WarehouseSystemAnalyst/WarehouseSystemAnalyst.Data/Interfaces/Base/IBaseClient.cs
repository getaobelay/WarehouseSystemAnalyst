using System;
using System.Collections.Generic;
using System.Text;
using WarehouseSystemAnalyst.Data.Entites.BaseEntites;
using WarehouseSystemAnalyst.Data.Implementation.BaseEntites;

namespace WarehouseSystemAnalyst.Data.Interfaces.Base
{
    public interface IBaseClient<TResponseModel, TRequstModel, TRequest, TResponse> : IBaseRepository<TRequstModel>
        where TResponseModel : BaseDtoModel, new()
        where TRequstModel : BaseEntity, new()
        where TRequest : class, IBaseRequest<TRequstModel, TResponseModel>, new()
        where TResponse : class, IBaseResponse<TResponseModel>, new()
    {
    }
}
