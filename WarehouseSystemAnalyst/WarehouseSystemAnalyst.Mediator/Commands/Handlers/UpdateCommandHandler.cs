using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Models;

namespace WarehouseSystemAnalyst.Mediator.Commands.Handlers
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TCommand"></typeparam>

    public class UpdateCommandHandler<TEntity, TCommand, TContext> : ICommandHandlerWrapper<TCommand, TEntity, TContext>
       where TEntity : class, new()
       where TContext : DbContext, new()
       where TCommand : class, ICommandWrapper<TEntity>, new()
    {

        private IWarehouseContext<TContext, TEntity> context;
        public UpdateCommandHandler(IWarehouseContext<TContext, TEntity> context)
        {
            Context = context;
        }

        public IWarehouseContext<TContext, TEntity> Context { get; set; }
        public async Task<ICommandResponse<TEntity>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await Context.Repository.UpdateAsync(request.Model);
                await Context.UnitOfWork.SaveChangesAsync();

                return (ICommandResponse<TEntity>)await Task.FromResult(CommandResponse.CommandExecuted<TEntity>(message: "Recored Deleted", request.Model));
            }
            catch (Exception)
            {
                return (ICommandResponse<TEntity>)await Task.FromResult(CommandResponse.CommandFailed<TEntity>(message: "Falid to delete record from the database"));

            }
        }
    }
}