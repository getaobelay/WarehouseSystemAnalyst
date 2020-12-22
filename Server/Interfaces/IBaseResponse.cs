using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Server.BaseContollers
{
    public interface IBaseResponse<TResponseDto>
        where TResponseDto : class, IBaseDto, new()
    {
        public bool Success { get; set; }
        public IEnumerable<string> ErrorsMessages { get; set; }
    }
}