using System;
using System.Collections.Generic;
using System.Text;
using WarehouseSystemAnalyst.Interfaces.Base;

namespace WarehouseSystemAnalyst.Interfaces.Responses
{
    public interface IWarehouseResponse<TResponseModel> :
        IBaseResponse<TResponseModel>
        where TResponseModel : class, new()
    {
    }
}
