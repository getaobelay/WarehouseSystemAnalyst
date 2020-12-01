using Microsoft.Extensions.DependencyInjection;
using WarehouseSystemAnalyst.Data.Implementation.BaseApi;
using WarehouseSystemAnalyst.Data.Implementation.BaseRepositories;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Interfaces.Base;
using WarehouseSystemAnalyst.Interfaces.Repository;

namespace WarehouseSystemAnalyst.Mediator.Services
{
    public static class BaseService
    {
        public static IServiceCollection AddBaseServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IQueryRepository<>), typeof(BaseDataRepository<>));
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseDataRepository<>));
            services.AddTransient(typeof(IBaseController<,,,>), typeof(BaseController<,,,>));
            services.AddTransient(typeof(IBaseRequest<,>), typeof(BaseRequest<,>));
            services.AddTransient(typeof(IBaseResponse<>), typeof(BaseResponse<>));
            services.AddTransient(typeof(IUnitOfWorkRepository<>), typeof(UnitOfWorkRepository<>));
            return services;
        }
    }
}