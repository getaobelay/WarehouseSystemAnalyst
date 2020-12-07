using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Interfaces.Responses
{
    public interface IQueryResponse<TDto>
        where TDto : class, IBaseDto, new()
    {
        public TDto ViewModel { get; set; }
        public bool Error { get; set; }
        string Message { get; set; }
    }
}