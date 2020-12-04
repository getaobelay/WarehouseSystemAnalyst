using MediatR;
using Microsoft.EntityFrameworkCore;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers
{
    public interface ITransactionHandlerWrapper<TIn,TSource, TSourceDto, TDestination, TDestinationDto> : IRequestHandler<TIn, ITransactionCommandResponse<TSourceDto, TDestinationDto>>
        where TIn : ITransactionWrapper<TSource, TSourceDto, TDestination, TDestinationDto>
        where TSource : class, IBaseEntity, new()
        where TDestination : class, IBaseEntity, new()
        where TDestinationDto : class, new()
        where TSourceDto : class, new()
    {
        public IUnitOfWorkRepository<WarehouseDbContext> UnitOfWork { get; }
}
}