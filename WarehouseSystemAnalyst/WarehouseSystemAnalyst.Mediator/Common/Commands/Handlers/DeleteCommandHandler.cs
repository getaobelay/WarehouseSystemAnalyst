using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.Mediator.Common.Responses;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Requests;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Common.Commands.Handlers
{
    /// <summary>
    /// Generic mediator handler creates a new record in the database
    /// </summary>
    /// <typeparam name="TEntity">The entity to insert into the database</typeparam>
    /// <typeparam name="TCommand">Type of ICommandWrapper command</typeparam>
    public class DeleteCommandHandler<TEntity, TDto, TCommand> : IRequestHandler<TCommand, ICommandResponse<TDto>>
        where TEntity : class, IBaseEntity, new()
        where TDto : BaseDto, new()
        where TCommand : class, IDeleteRequest<TEntity, TDto>, new()
    {
        private IBaseRepository<TEntity> repository;

        public DeleteCommandHandler(IDataContext<WarehouseDbContext, TEntity> context)
        {
            WarehouseContext = context;
            repository = new DataRepository<TEntity>(WarehouseContext.UnitOfWork);
        }

        public IDataContext<WarehouseDbContext, TEntity> WarehouseContext { get; set; }

        public async Task<ICommandResponse<TDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await repository.DeleteAsync(12);
                await WarehouseContext.UnitOfWork.SaveChangesAsync();

                return await Task.FromResult(CommandResponse.CommandExecuted<TDto>(message: "Recored Deleted", default));
            }
            catch (Exception)
            {
                return await Task.FromResult(CommandResponse.CommandFailed<TDto>(message: "Falid to delete record from the database"));
            }
        }
    }
}