using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Models;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.Interfaces.CQRS.Wrappers;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Helpers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;
using WarehouseSystemAnalyst.Mediator.Models;

namespace WarehouseSystemAnalyst.Mediator.Commands.Handlers.CreateCommands
{
    /// <summary>
    /// Generic mediator handler creates a new record in the database
    /// </summary>
    /// <typeparam name="TEntity">The entity to insert into the database</typeparam>
    /// <typeparam name="TCommand">Type of ICommandWrapper command</typeparam>
    public class CreateCommandHandler<TEntity, TDto, TCommand> : IRequestHandler<TCommand, ICommandResponse<TDto>>
    where TEntity : class, IBaseEntity, new()
    where TDto : BaseDto, new()
    where TCommand : class, ICommandRequest<TEntity, TDto>, new()
    {
        private readonly IBaseRepository<TEntity> repository;

        public CreateCommandHandler(IDataContext<WarehouseDbContext, TEntity> context)
        {
            WarehouseContext = context;
            repository = new DataRepository<TEntity>(WarehouseContext.UnitOfWork);
        }

        public IDataContext<WarehouseDbContext, TEntity> WarehouseContext { get; set; }

        public async Task<ICommandResponse<TDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await repository.InsertAsync(MappingHelper.Mapper.Map<TEntity>(request.Entity));
                await WarehouseContext.UnitOfWork.SaveChangesAsync();

                var mapped = MappingHelper.Mapper.Map<TDto>(result);

                return await Task.FromResult(CommandResponse.CommandExecuted(message: "Recored Created", mapped));
            }
            catch (Exception)
            {
                return await Task.FromResult(CommandResponse.CommandFailed<TDto>(message: "Falid to insert record into database"));
            }
        }
    }
}