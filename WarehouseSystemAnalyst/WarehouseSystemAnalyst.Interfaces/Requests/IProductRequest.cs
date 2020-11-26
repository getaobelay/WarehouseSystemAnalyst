using System;
using System.Collections.Generic;
using System.Text;
using WarehouseSystemAnalyst.Interfaces.Base;

namespace WarehouseSystemAnalyst.Interfaces.Requests
{
    public interface IProductRequest<TRequestModel , TResponseModel> :
        IBaseRequest<TRequestModel, TResponseModel>
        where TResponseModel : class, new()
        where TRequestModel : class, new()
    {

    }
}
