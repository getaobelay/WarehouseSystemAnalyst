using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Server.BaseContollers;

namespace WarehouseSystemAnalyst.Blazor.Server.Models.Requests
{
    public class APIRequest<TEntity, TDto> : IBaseRequest<TEntity, TDto>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
        public object Id { get; set; }
    }
}