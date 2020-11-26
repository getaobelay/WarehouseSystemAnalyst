using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using WarehouseSystemAnalyst.Interfaces.CQRS.Models;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;
using WarehouseSystemAnalyst.Mediator.Models;

namespace WarehouseSystemAnalyst.Mediator.Commands.Handlers
{
    public class DeleteCommandHandler<TEntity, TCommand, TContext> : ICommandHandlerWrapper<TCommand, TEntity, TContext>
        where TEntity : class, new()
        where TContext : DbContext, new()
        where TCommand : class, ICommandWrapper<TEntity>, new()
    {

        private IWarehouseContext<TContext, TEntity> context;
        public DeleteCommandHandler(IWarehouseContext<TContext, TEntity> context)
        {
            Context = context;
        }

        public IWarehouseContext<TContext, TEntity> Context { get; set; }
        public async Task<ICommandResponse<TEntity>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await Context.Repository.DeleteAsync(12);
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
