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
    public class CreateWarehouseCommandHandler<TSource, TSourceDto, TDestination, TDestinationDto, TCommand> : ITransactionHandlerWrapper<TCommand, TSource, TSourceDto, TDestination, TDestinationDto>
    where TSource : class, IBaseWarehouse, new()
    where TDestination : class, IBaseWarehouse, new()
    where TSourceDto : class, new()
    where TDestinationDto : class, new()
    where TCommand : class, ITransactionWrapper<TSource, TSourceDto, TDestination, TDestinationDto>, new()
    {
        public IUnitOfWorkRepository<WarehouseDbContext> UnitOfWork { get; }
        public IWarehouseRepository<TSource, TDestination> repository { get; set; }
        public CreateWarehouseCommandHandler(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork)
        {
            UnitOfWork = unitOfWork;
            repository = new WarehouseRepository<TSource, TDestination>(UnitOfWork);
        }

        public async Task<ITransactionCommandResponse<TSourceDto, TDestinationDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {


            ITransactionCommandResponse<TSourceDto, TDestinationDto> response = null;

            try
            {
                var exists = await repository.GetSingleAsync(s => s.WarehouseName == request.Name, d => d.WarehouseName == request.Name);

                if (exists.source != null && exists.destination != null)
                {
                    response.Error = true;
                    response.Messages = new List<string>() { "Already exists in both" };
                    return response;
                }

                await UnitOfWork.CreateTransactionAsync();

                var sourceToCreate = request.Source;
                var destToCreate = request.Destination;
                sourceToCreate.WarehouseName = destToCreate.WarehouseName = request.Name;

                var result = await repository.InsertAsync(request.Source, request.Destination);

                await UnitOfWork.CommitAsync();

                if (result.source == null || result.destination == null)
                {
                    response.Error = true;
                    response.Messages = new List<string>() { "Failed to update" };
                    await UnitOfWork.RollbackAsync();

                    return response;
                }

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
