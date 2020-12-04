using arehouseSystemAnalyst.Data.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;
using WarehouseSystemAnalyst.Mediator.Helpers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Commands.Handlers.UpdateCommands
{
    /// <summary>
    /// Generic mediator handler handles warehouse transaction  updated given source and destination
    /// </summary>
    /// <typeparam name="TSource">The source entity to update</typeparam>
    /// <typeparam name="TDestination">The destination entity to update</typeparam>
    /// <typeparam name="TSourceDto">The source dto to map result from</typeparam>
    /// <typeparam name="TDestinationDto">The destination dto to map result from</typeparam>
    /// <typeparam name="TCommand">Type of ICommandWrapper command</typeparam>
    public class UpdateWarehouseCommandHandler<TSource, TSourceDto, TDestination, TDestinationDto, TCommand> : ITransactionHandlerWrapper<TCommand, TSource, TSourceDto, TDestination, TDestinationDto>
    where TSource : class, IBaseWarehouse, new()
    where TDestination : class, IBaseWarehouse, new()
    where TSourceDto : class, new()
    where TDestinationDto : class, new()
    where TCommand : class, ITransactionWrapper<TSource,TSourceDto, TDestination, TDestinationDto>, new()
    {
        public IUnitOfWorkRepository<WarehouseDbContext> UnitOfWork { get; }
        public IWarehouseRepository<TSource, TDestination> repository { get; set; }
        public UpdateWarehouseCommandHandler(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork)
        {
            UnitOfWork = unitOfWork;
            repository = new WarehouseRepository<TSource, TDestination>(UnitOfWork);
        }

        public async Task<ITransactionCommandResponse<TSourceDto, TDestinationDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            ITransactionCommandResponse<TSourceDto, TDestinationDto> response = null;

            try
            {
                var findResult = await repository.GetSingleAsync(
                    s => s.PK.Equals(request.SourceId),
                    d => d.PK.Equals(request.DestinationId));

                if (findResult.source == null && findResult.destination == null)
                {
                    response.Error = true;
                    response.Messages = new List<string>() { $"failed to find {nameof(TSource)} in the database",
                        { $"failed to find {nameof(TDestination)} in the database" } };
                    return response;
                }

                else if (findResult.source == null)
                {
                    response.DestinationModel = MappingHelper.Mapper.Map<TDestinationDto>(findResult.destination);
                    response.Error = true;
                    response.Messages = new List<string>() { $"failed to find {nameof(TSource)} in the database" };
                    return response;
                }

                else if (findResult.destination == null)
                {
                    response.sourceModel = MappingHelper.Mapper.Map<TSourceDto>(findResult.source);
                    response.Error = true;
                    response.Messages = new List<string>() { $"failed to find {nameof(TDestination)} in the database" };
                    return response;
                }

                else
                {
                    var sourceToUpdate = MappingHelper.Mapper.Map<TSource>(request.Source);
                    var destToUpdate = MappingHelper.Mapper.Map<TDestination>(request.Destination);

                    findResult.source = sourceToUpdate;
                    findResult.destination = destToUpdate;

                    await UnitOfWork.CreateTransactionAsync();

                    var updateResult = await repository.UpdateAsync(findResult.source, findResult.destination);

                    await UnitOfWork.CommitAsync();

                    if (findResult.source == null || findResult.destination == null)
                    {
                        response.Error = true;
                        response.Messages = new List<string>() { "Failed to update" };
                        await UnitOfWork.RollbackAsync();

                        return response;
                    }

                    response.Error = false;
                    response.sourceModel = MappingHelper.Mapper.Map<TSourceDto>(response.sourceModel);
                    response.DestinationModel = MappingHelper.Mapper.Map<TDestinationDto>(response.DestinationModel);

                    return response;
                }

            }
            catch (Exception)
            {
                await UnitOfWork.RollbackAsync();
                throw;
            }
        }
    }

}
