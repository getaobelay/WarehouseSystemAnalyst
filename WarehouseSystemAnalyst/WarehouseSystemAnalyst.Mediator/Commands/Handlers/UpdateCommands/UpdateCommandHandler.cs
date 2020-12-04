using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;
using WarehouseSystemAnalyst.Mediator.Models;

namespace WarehouseSystemAnalyst.Mediator.Commands.Handlers.UpdateCommands
{
    /// <summary>
    /// Generic mediator handler creates a new record in the database
    /// </summary>
    /// <typeparam name="TEntity">The entity to insert into the database</typeparam>
    /// <typeparam name="TCommand">Type of ICommandWrapper command</typeparam>
    public class UpdateCommandHandler<TEntity, TCommand> : ICommandHandlerWrapper<TCommand, TEntity>
       where TEntity : class, IBaseEntity, new()
       where TCommand : class, ICommandWrapper<TEntity>, new()
    {
        private IWarehouseContext<WarehouseDbContext, TEntity> context;

        public UpdateCommandHandler(IWarehouseContext<WarehouseDbContext, TEntity> context)
        {
            WarehouseContext = context;
        }

        public IWarehouseContext<WarehouseDbContext, TEntity> WarehouseContext { get; set; }

        public async Task<ICommandResponse<TEntity>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await WarehouseContext.Repository.UpdateAsync(request.Model);
                await WarehouseContext.UnitOfWork.SaveChangesAsync();

                return await Task.FromResult(CommandResponse.CommandExecuted(message: "Recored Deleted", request.Model));
            }
            catch (Exception)
            {
                return await Task.FromResult(CommandResponse.CommandFailed<TEntity>(message: "Falid to delete record from the database"));
            }
        }
    }
}