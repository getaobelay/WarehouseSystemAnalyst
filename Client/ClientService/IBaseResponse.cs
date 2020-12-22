using System.Collections.Generic;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.BlazorUI.Client.ClientService
{
    public interface IBaseResponse<TResponseDto>
        where TResponseDto : class, IBaseDto, new()
    {
        public bool Success { get; set; }
        public List<string> ErrorsMessages { get; set; }
    }
}