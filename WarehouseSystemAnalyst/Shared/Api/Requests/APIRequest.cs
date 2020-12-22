using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Shared.Api.Requests
{
    public class APIRequest<TEntity, TDto> : IBaseRequest<TEntity, TDto>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
        public object Id { get; set; }
    }
}