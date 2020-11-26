using Microsoft.Extensions.DependencyInjection;
using WarehouseSystemAnalyst.Interfaces.Base;
using WarehouseSystemAnalyst.Interfaces.Repository;
using WarehouseSystemAnalyst.Services.Base;
using WarehouseSystemAnalyst.Services.Repository;

namespace WarehouseSystemAnalyst.Configurations.Services
{
    public static class BaseService
    {
        public static IServiceCollection AddBaseServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IQueryRepository<>), typeof(BaseRepository<>));
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient(typeof(IBaseController<,,,>), typeof(BaseController<,,,>));
            services.AddTransient(typeof(IBaseRequest<,>), typeof(BaseRequest<,>));
            services.AddTransient(typeof(IBaseResponse<>), typeof(BaseResponse<>));
            services.AddTransient(typeof(IUnitOfWorkRepository<>), typeof(UnitOfWorkRepository<>));
            return services;
        }
    }
}