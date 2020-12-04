using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Commands.Requests.CreateCommands
{
    /// <summary>
    /// this command creates mission source and destination entities
    /// </summary>
    /// <typeparam name="TSource">The source entity to insert into the database</typeparam>
    /// <typeparam name="TDestination">The destination entity to insert into the database</typeparam>
    /// <typeparam name="TSourceDto">The source dto to map result from</typeparam>
    /// <typeparam name="TDestinationDto">The source  dto to map result from</typeparam>
    public class UpdateTransactionCommand<TSource, TSourceDto , TDestination, TDestinationDto> : ITransactionWrapper<TSource, TSourceDto, TDestination, TDestinationDto>
       where TSource : class, IBaseEntity, new()
       where TDestination : class, IBaseEntity, new()
       where TSourceDto : class, new()
       where TDestinationDto : class, new()

    {
        public string Name { get; set; }
        public TSource Source { get; set; }
        public object SourceId { get; set; }
        public object DestinationId { get; set; }
        public TDestination Destination { get; set; }
    }
}