using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Interfaces.Base;

namespace WarehouseSystemAnalyst.Mediator.Requests
{
    public class BaseResponse<TResponseDto> : IBaseResponse<TResponseDto>
        where TResponseDto : class, new()
    {
        public bool Success { get; set; }
        public List<string> ErrorMessages { get; set; }
        public TResponseDto Data { get; set; }
    }
}