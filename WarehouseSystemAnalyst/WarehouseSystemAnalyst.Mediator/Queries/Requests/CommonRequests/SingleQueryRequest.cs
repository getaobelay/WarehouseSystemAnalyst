using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Queries.Responses.CommonResponses;

namespace WarehouseSystemAnalyst.Mediator.Queries.Requests.CommonRequests
{
    public class SingleQueryRequest<TEntity, TDto> : IRequest<SingleQueryResponse<TDto>>
       where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
        public object Id { get; set; }
        public Expression<Func<TEntity, bool>> Filter { get; set; }
    }
}