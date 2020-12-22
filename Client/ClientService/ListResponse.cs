using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.BlazorUI.Client.ClientService
{

    public class ListResponse<TResponseDto>
        where TResponseDto : class, IBaseDto, new()
    {
        public bool Success { get; set; }
        public List<string> ErrorsMessages { get; set; }
        public List<TResponseDto> Object { get; set; }
    }
}