using System.Collections.Generic;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Shared.Api.Responses
{
    public interface IBaseResponse<TResponseDto>
        where TResponseDto : class, IBaseDto, new()
    {
        public bool Success { get; set; }
        public IEnumerable<string> ErrorsMessages { get; set; }
    }
}