using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Implementation;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Responses;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;
using WarehouseSystemAnalyst.Shared.Dtos.BaseDtos;

namespace WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Handlers
{
    /// <summary>
    /// Generic mediator handler creates a new record in the database
    /// </summary>
    /// <typeparam name="TEntity">The entity to insert into the database</typeparam>
    /// <typeparam name="TCommand">Type of ICommandWrapper command</typeparam>
    public class DeleteCommandHandler<TEntity, TDto, TCommand> : IRequestHandler<TCommand, CommandResponse<TDto>>
         where TEntity : class, IBaseEntity, new()
         where TDto : class, IBaseDto, new()
         where TCommand : DeleteCommandRequest<TEntity, TDto>, new()
    {
        private DataRepository<TEntity> repository;

        public DeleteCommandHandler(IDataContext context)
        {
            repository = new DataRepository<TEntity>(context.UnitOfWork);
        }


        public async Task<CommandResponse<TDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var entityEntry = await repository.SingleOrDefaultAsync(p => p.PK == request.Id.ToString());

                if (entityEntry == null)
                {
                    return await Task.FromResult(CommandResponse.CommandFailed<TDto>(message: $"Record with id {request.Id} not found"));

                }

                repository.Context.Entry(entityEntry).State = EntityState.Detached;

                var result = await repository.DeleteAsync(entityEntry);
                await repository.UnitOfWork.SaveChangesAsync();


                if (result)
                {
                    return await Task.FromResult(CommandResponse.CommandExecuted<TDto>(message: "Recored Deleted", default));
                }

                return await Task.FromResult(CommandResponse.CommandFailed<TDto>(message: "Failed to delete record from the database"));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}