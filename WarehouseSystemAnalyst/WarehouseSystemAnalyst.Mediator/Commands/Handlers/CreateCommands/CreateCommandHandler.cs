using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;
using WarehouseSystemAnalyst.Mediator.Models;

namespace WarehouseSystemAnalyst.Mediator.Commands.Handlers.CreateCommands
{

    /// <summary>
    /// Generic mediator handler creates a new record in the database
    /// </summary>
    /// <typeparam name="TEntity">The entity to insert into the database</typeparam>
    /// <typeparam name="TCommand">Type of ICommandWrapper command</typeparam>
    public class CreateCommandHandler<TEntity, TCommand> : ICommandHandlerWrapper<TCommand, TEntity>
        where TEntity : class, IBaseEntity, new()
        where TCommand : class, ICommandWrapper<TEntity>, new()
    {
        private IWarehouseContext<WarehouseDbContext, TEntity> context;

        public CreateCommandHandler(IWarehouseContext<WarehouseDbContext, TEntity> context)
        {
            WarehouseContext = context;
        }

        public IWarehouseContext<WarehouseDbContext, TEntity> WarehouseContext { get; set; }

        public async Task<ICommandResponse<TEntity>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await context.Repository.InsertAsync(request.Model);
                await context.UnitOfWork.SaveChangesAsync();

                return await Task.FromResult(CommandResponse.CommandExecuted(message: "Recored Created", request.Model));
            }
            catch (Exception)
            {
                return await Task.FromResult(CommandResponse.CommandFailed<TEntity>(message: "Falid to insert record into database"));
            }
        }
    }
}