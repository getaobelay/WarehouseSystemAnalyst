using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Interfaces.CQRS.Behaviours;

namespace WarehouseSystemAnalyst.Mediator.Behaviours
{

    public class UserActionBehaviour<TRequest, TResponse, TContext, TModel> : IPipelineBehavior<TRequest, TResponse>
      where TRequest : IUserActionPipe<TContext, TModel>
      where TContext : DbContext, new()
      where TModel : class, new()
    {
        private readonly ILogger<UserActionBehaviour<TRequest, TResponse, TContext, TModel>> _logger;

        public UserActionBehaviour(ILogger<UserActionBehaviour<TRequest, TResponse, TContext, TModel>> logger)
        {
            _logger = logger ?? throw new ArgumentException(nameof(ILogger));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = default;


            _logger.LogInformation($"Begin User Enrollment {typeof(TRequest).Name}");
            response = await next();
            _logger.LogInformation($"Committed transaction {typeof(TRequest).Name}");

            return response;

        }
    }
}
