using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Context;
using WarehouseSystemAnalyst.Interfaces.CQRS.Behaviours;

namespace WarehouseSystemAnalyst.Mediator.Behaviours
{
    public class CommandBehaviour<TRequest, TResponse, TModel> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommandPipe<WarehouseDbContext, TModel>
        where TModel : class, new()
    {
        private readonly ILogger<CommandBehaviour<TRequest, TResponse, TModel>> _logger;
        public CommandBehaviour(ILogger<CommandBehaviour<TRequest, TResponse, TModel>> logger)
        {
            _logger = logger ?? throw new ArgumentException(nameof(ILogger));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = default;

            try
            {
                await request.Context.UnitOfWork.CreateTransactionAsync();
                _logger.LogInformation($"Begin transaction {typeof(TRequest).Name}");
                response = await next();
                await request.Context.UnitOfWork.CommitAsync();
                _logger.LogInformation($"Committed transaction {typeof(TRequest).Name}");

                return response;
            }

            catch (Exception e)
            {
                _logger.LogInformation($"Rollback transaction executed {typeof(TRequest).Name}");

                await request.Context.UnitOfWork.RollbackAsync();

                _logger.LogError(e.Message, e.StackTrace);

                throw;
            }
        }
    }
}
