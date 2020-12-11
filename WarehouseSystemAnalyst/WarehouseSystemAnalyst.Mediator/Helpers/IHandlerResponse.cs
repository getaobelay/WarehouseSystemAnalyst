using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Helpers
{
    public interface IHandlerResponse<TDto>
        where TDto : class, IBaseDto, new()
    {
        public bool Success { get; set; }
        public IEnumerable<string> ErrorsMessages { get; set; }
    }
}