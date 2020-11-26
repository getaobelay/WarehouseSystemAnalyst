using System;
using System.Collections.Generic;
using System.Text;
using WarehouseSystemAnalyst.Interfaces.Base;

namespace WarehouseSystemAnalyst.Interfaces.Responses
{
    public interface IProductResponse<TResponseModel> :
        IBaseResponse<TResponseModel>
        where TResponseModel : class, new()
    {
    }
}
