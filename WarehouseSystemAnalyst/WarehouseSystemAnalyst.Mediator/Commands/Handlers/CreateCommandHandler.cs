using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Models;
using WarehouseSystemAnalyst.Mediator.Models;

namespace WarehouseSystemAnalyst.Mediator.Commands.Handlers
{

    public class CreateCommandHandler<TEntity, TCommand, TContext> : ICommandHandlerWrapper<TCommand, TEntity, TContext>
        where TEntity : class, new()
        where TContext : DbContext, new()
        where TCommand : class, ICommandWrapper<TEntity>, new()
    {

        private IWarehouseContext<TContext, TEntity> context;
        public CreateCommandHandler(IWarehouseContext<TContext, TEntity> context)
        {
            Context = context;
        }

        public IWarehouseContext<TContext, TEntity> Context { get; set; }
        public async Task<ICommandResponse<TEntity>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await context.Repository.InsertAsync(request.Model);
                await context.UnitOfWork.SaveChangesAsync();

                return (ICommandResponse<TEntity>)await Task.FromResult(CommandResponse.CommandExecuted<TEntity>(message: "Recored Created", request.Model));
            }
            catch (Exception)
            {
                return (ICommandResponse<TEntity>)await Task.FromResult(CommandResponse.CommandFailed<TEntity>(message: "Falid to insert record into database"));

            }

        }
    }

}

