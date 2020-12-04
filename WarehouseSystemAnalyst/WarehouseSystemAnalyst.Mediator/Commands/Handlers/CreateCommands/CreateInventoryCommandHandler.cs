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

namespace WarehouseSystemAnalyst.Mediator.Commands.Handlers.CreateCommands
{
    /// <summary>
    /// Generic mediator handler handles inventory transaction creates given source and destination
    /// </summary>
    /// <typeparam name="TSource">The source entity to update</typeparam>
    /// <typeparam name="TDestination">The destination entity to update</typeparam>
    /// <typeparam name="TSourceDto">The source dto to map result from</typeparam>
    /// <typeparam name="TDestinationDto">The destination dto to map result from</typeparam>
    /// <typeparam name="TCommand">Type of ICommandWrapper command</typeparam>

    public class CreateInventoryCommandHandler<TSource, TSourceDto , TDestination, TDestinationDto, TCommand> : ITransactionHandlerWrapper<TCommand, TSource, TSourceDto, TDestination, TDestinationDto>
        where TSource : class, IBaseStock, new()
        where TDestination : class, IBaseStock, new()
        where TSourceDto : class, new()
        where TDestinationDto : class, new()
        where TCommand : class, ITransactionWrapper<TSource, TSourceDto, TDestination, TDestinationDto>, new()
    {
        public IUnitOfWorkRepository<WarehouseDbContext> UnitOfWork { get; }
        public IInventoryRepository<TSource, TDestination> repository { get; set; }
        public CreateInventoryCommandHandler(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork)
        {
            UnitOfWork = unitOfWork;
            repository = new InventoryRepository<TSource, TDestination>(UnitOfWork);
        }

        public async Task<ITransactionCommandResponse<TSourceDto, TDestinationDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            var sourceToCreate = request.Source;
            var destToCreate = request.Destination ;

            ITransactionCommandResponse<TSourceDto, TDestinationDto> response = null;

            try
            {
                var exists = await repository.GetSingleAsync(s => s.Name == request.Name, d => d.Name == request.Name);

                if (exists.source != null && exists.destination != null)
                {
                    response.Error = true;
                    response.Messages = new List<string>() { "Already exists in both" };
                    return response;
                }

                sourceToCreate.Name = destToCreate.Name = request.Name;

                await UnitOfWork.CreateTransactionAsync();

                var result = await repository.InsertAsync(request.Source, request.Destination);

                await UnitOfWork.CommitAsync();

                if(result.source == null || result.destination == null)
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

            catch (Exception)
            {
                await UnitOfWork.RollbackAsync();
                throw;
            }

        }
    }

}
