using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Common.Commands.Requests;
using WarehouseSystemAnalyst.Mediator.CommonCQRS.Commands.Responses;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Helpers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Common.Commands.Handlers
{
    /// <summary>
    /// Generic mediator handler creates a new record in the database
    /// </summary>
    /// <typeparam name="TEntity">The entity to insert into the database</typeparam>
    /// <typeparam name="TCommand">Type of ICommandWrapper command</typeparam>
    public class UpdateCommandHandler<TEntity, TDto, TCommand> : IRequestHandler<TCommand, CommandResponse<TDto>>
       where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
        where TCommand : UpdateCommandRequest<TEntity, TDto>, new()
    {
        private DataRepository<TEntity> repository;

        public UpdateCommandHandler(IDataContext context)
        {
            repository = new DataRepository<TEntity>(context.UnitOfWork);
        }

        public async Task<CommandResponse<TDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var is_exists = await repository.SingleOrDefaultAsync(p=> p.PK == request.Id.ToString());
                if (is_exists == null)
                {
                    return await Task.FromResult(CommandResponse.CommandFailed<TDto>(message: $"Record with id {request.Id} not found"));

                }

                var mappedObject = MappingHelper.Mapper.Map<TEntity>(request.Entity);
                mappedObject.Id = is_exists.Id;

                var result = await repository.UpdateAsync(mappedObject);
                await repository.UnitOfWork.SaveChangesAsync();

                if(result != null)
                {
                    var mapped = MappingHelper.Mapper.Map<TDto>(result);
                    return await Task.FromResult(CommandResponse.CommandExecuted(message: "Recored Updated", mapped));
                }

                await repository.UnitOfWork.RollbackAsync();
                return await Task.FromResult(CommandResponse.CommandFailed<TDto>(message: "Failed to updated record from the database"));

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}