using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Server.BaseContollers;

namespace WarehouseSystemAnalyst.Blazor.Server.Models.Requests
{
    public class APIQueryResponse<TResponseDto> : IBaseResponse<TResponseDto>
        where TResponseDto : class, IBaseDto, new()
    {
        public IEnumerable<TResponseDto> ObjectCollection { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> ErrorsMessages { get; set; }
    }
}