using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Server.BaseContollers
{
    public class BaseRequest<TEntity, TDto> : IBaseRequest<TEntity, TDto>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
        public object Id { get; set; }
    }
}