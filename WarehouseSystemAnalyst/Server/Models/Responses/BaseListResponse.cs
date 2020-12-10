using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Server.BaseContollers
{
    public class BaseListResponse<TResponseDto>  : IBaseResponse<TResponseDto>
        where TResponseDto : class, IBaseDto, new()
    {
        public IEnumerable<TResponseDto> ObjectCollection { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> ErrorsMessages { get; set; }
    }
}