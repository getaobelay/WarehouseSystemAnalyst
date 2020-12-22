using System.Collections.Generic;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Blazor.Client.ClientService
{

    public class ListResponse<TResponseDto>
        where TResponseDto : class, IBaseDto, new()
    {
        public bool Success { get; set; }
        public List<string> ErrorsMessages { get; set; }
        public List<TResponseDto> Object { get; set; }
    }
}