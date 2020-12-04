using MediatR;
using System;
using System.Linq.Expressions;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers
{
    public interface ITransactionWrapper<TSource, TSourceDto, TDestination, TDestinationDto> : IRequest<ITransactionCommandResponse<TSourceDto, TDestinationDto>>
        where TSource : class, IBaseEntity, new()
        where TDestination : class, IBaseEntity, new()
        where TSourceDto : class, new()
        where TDestinationDto : class, new()
    {
        public string Name { get; set; }
        public object SourceId { get; set; }
        public object DestinationId { get; set; }
        public TSource Source { get; set; }
        public TDestination Destination { get; set; }
    }
}