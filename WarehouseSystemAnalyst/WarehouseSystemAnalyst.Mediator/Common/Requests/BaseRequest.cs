using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Base;

namespace WarehouseSystemAnalyst.Mediator.Common.Requests
{
    public class BaseRequest<TRequestEntity, TResponseDto> : IBaseRequest<TRequestEntity, TResponseDto>
        where TRequestEntity : class, IBaseEntity, new()
        where TResponseDto : class, IBaseDto, new()
    {
        public object Id { get; set; }
        public List<string> ErrorMessages { get; set; }
        public TResponseDto Data { get; set; }
    }
}