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
using WarehouseSystemAnalyst.Mediator.Helpers;
using WarehouseSystemAnalyst.Mediator.Interfaces.Requests;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Common.Commands.Handlers
{
    /// <summary>
    /// Generic mediator handler creates a new record in the database
    /// </summary>
    /// <typeparam name="TEntity">The entity to insert into the database</typeparam>
    /// <typeparam name="TCommand">Type of ICommandWrapper command</typeparam>
    public class UpdateCommandHandler<TEntity, TDto, TCommand> : IRequestHandler<TCommand, ICommandResponse<TDto>>
       where TEntity : class, IBaseEntity, new()
        where TDto : BaseDto, new()
        where TCommand : class, IUpdateRequest<TEntity, TDto>, new()
    {
        private IBaseRepository<TEntity> repository;

        public UpdateCommandHandler(IDataContext<WarehouseDbContext, TEntity> context)
        {
            WarehouseContext = context;
            repository = new DataRepository<TEntity>(WarehouseContext.UnitOfWork);
        }

        public IDataContext<WarehouseDbContext, TEntity> WarehouseContext { get; set; }

        public async Task<ICommandResponse<TDto>> Handle(TCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await repository.UpdateAsync(request.Entity);
                await WarehouseContext.UnitOfWork.SaveChangesAsync();

                var mapped = MappingHelper.Mapper.Map<TDto>(result);

                return await Task.FromResult(CommandResponse.CommandExecuted(message: "Recored Updated", mapped));
            }
            catch (Exception)
            {
                return await Task.FromResult(CommandResponse.CommandFailed<TDto>(message: "Falid to delete record from the database"));
            }
        }
    }
}