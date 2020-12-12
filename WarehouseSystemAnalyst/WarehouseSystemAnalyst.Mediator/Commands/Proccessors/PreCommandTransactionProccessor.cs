using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Mediator.Commands.Requests.CommonRequests;
using WarehouseSystemAnalyst.Mediator.Commands.Responses.CommonResponses;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Responses;

namespace WarehouseSystemAnalyst.Mediator.Commands.Proccessors
{
    public class PreCommandTransactionProccessor<TRequest, TResponse, TEntity, TDto> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : BaseCommandRequest<TEntity, TDto>
        where TResponse : BaseCommandResponse<TDto>
        where TEntity : class, IBaseEntity, new()
        where TDto : class, IBaseDto, new()
    {
        private readonly ILogger<PreCommandTransactionProccessor<TRequest, TResponse, TEntity, TDto>> _logger;
        public PreCommandTransactionProccessor(ILogger<PreCommandTransactionProccessor<TRequest, TResponse, TEntity, TDto>> logger, IDataContext context)
        {
            _logger = logger ?? throw new ArgumentException(nameof(ILogger));
            Context = context;
        }

        public IDataContext Context { get; }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = default;

            try
            {
                await Context.UnitOfWork.CreateTransactionAsync();
                _logger.LogInformation($"Begin transaction {typeof(TRequest).Name}");

                response = await next();

                await Context.UnitOfWork.CommitAsync();
                _logger.LogInformation($"Committed transaction {typeof(TRequest).Name}");

                return response;
            }

            catch (Exception e)
            {
                _logger.LogInformation($"Rollback transaction executed {typeof(TRequest).Name}");

                await Context.UnitOfWork.RollbackAsync();

                _logger.LogError(e.Message, e.StackTrace);

                throw;
            }
        }
    }
}
