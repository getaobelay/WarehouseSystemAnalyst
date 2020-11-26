using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseSystemAnalyst.Interfaces.Base
{
    public interface IBaseResponse<TResponseModel>
        where TResponseModel : class, new()
    {
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; }
        public TResponseModel Data { get; set; }
    }
}
