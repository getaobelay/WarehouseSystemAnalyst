using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Blazor.Client.ClientService
{

    public abstract class BaseResponse<TResponseDto> : IBaseResponse<TResponseDto>
        where TResponseDto : class, IBaseDto, new()
    {
        public object Object { get; set; }
        public bool Success { get; set; }
        public List<string> ErrorsMessages { get; set; }
    }
}