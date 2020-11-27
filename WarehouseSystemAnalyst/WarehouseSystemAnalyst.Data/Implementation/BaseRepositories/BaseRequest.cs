using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Interfaces.Base;

namespace WarehouseSystemAnalyst.Data.Implementation.BaseRepositories
{
    public class BaseRequest<TRequestModel, TResponseModel> : IBaseRequest<TRequestModel, TResponseModel>
        where TRequestModel : class, new()
        where TResponseModel : class, new()
    {
        public object Id { get; set; }
        public List<string> ErrorMessages { get; set; }
        public TResponseModel Data { get; set; }
    }
}
