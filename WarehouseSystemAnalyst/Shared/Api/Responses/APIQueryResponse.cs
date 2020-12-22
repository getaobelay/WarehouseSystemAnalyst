using System.Collections.Generic;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Shared.Api.Responses
{
    public class APIQueryResponse<TResponseDto> : IBaseResponse<TResponseDto>
        where TResponseDto : class, IBaseDto, new()
    {
        public IEnumerable<TResponseDto> ObjectCollection { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> ErrorsMessages { get; set; }
    }
}