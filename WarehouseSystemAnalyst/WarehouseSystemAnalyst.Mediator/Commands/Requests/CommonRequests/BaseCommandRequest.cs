using MediatR;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.Commands.Responses.CommonResponses;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.Mediator.Commands.Requests.CommonRequests
{
    public abstract class BaseCommandRequest<TEntity, TDto> : ICommandRequest<TEntity, TDto>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
        public TDto Dto { get; set; }
        public bool Error { get; set; }
        public List<string> ErrorMessages { get; set; }
    }

}
