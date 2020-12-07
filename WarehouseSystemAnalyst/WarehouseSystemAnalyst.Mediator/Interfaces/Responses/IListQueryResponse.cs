using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Responses
{

    public interface IListQueryResponse<TDto>
        where TDto : class, IBaseDto, new()
    {
        public IEnumerable<TDto> ViewModelList { get; set; }
        public bool Error { get; set; }
        string Message { get; set; }
    }
}