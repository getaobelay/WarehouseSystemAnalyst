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
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Commands.Handlers.DeleteCommands
{
    /// <summary>
    /// Generic mediator handler handles inventory transaction creates given source and destination
    /// </summary>
    /// <typeparam name="TSource">The source entity to update</typeparam>
    /// <typeparam name="TDestination">The destination entity to update</typeparam>
    /// <typeparam name="TSourceDto">The source dto to map result from</typeparam>
    /// <typeparam name="TDestinationDto">The destination dto to map result from</typeparam>
    /// <typeparam name="TCommand">Type of ICommandWrapper command</typeparam>
    public class DeleteInventoryCommandHandler<TSource, TSourceDto, TDestination, TDestinationDto, TCommand> : ITransactionHandlerWrapper<TCommand, TSource, TSourceDto, TDestination, TDestinationDto>
    where TSource : class, IBaseStock, new()
    where TDestination : class, IBaseStock, new()
    where TSourceDto : class, new()
    where TDestinationDto : class, new()
    where TCommand : class, ITransactionWrapper<TSource, TSourceDto, TDestination, TDestinationDto>, new()
    {
        public IUnitOfWorkRepository<WarehouseDbContext> UnitOfWork { get; }
        public IInventoryRepository<TSource, TDestination> repository { get; set; }
        public DeleteInventoryCommandHandler(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork)
        {
            UnitOfWork = unitOfWork;
            repository = new InventoryRepository<TSource, TDestination>(UnitOfWork);
        }

        public async Task<ITransactionCommandResponse<TSourceDto, TDestinationDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            ITransactionCommandResponse<TSourceDto, TDestinationDto> response = null;

            try
            {
                await UnitOfWork.CreateTransactionAsync();

                var result = await repository.DeleteAsync(request.SourceId, request.DestinationId);

                await UnitOfWork.CommitAsync();

                if (!result)
                {
                    await UnitOfWork.RollbackAsync();

                    response.Error = true;
                    response.Messages = new List<string>() { $"failed to delete {nameof(TSource)} in the database",
                        { $"failed to delete {nameof(TDestination)} in the database" } };

                    return response;
                }

                else
                {
                    response.Error = false;

                    await UnitOfWork.RollbackAsync();
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
