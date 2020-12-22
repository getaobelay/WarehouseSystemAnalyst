using System.Threading.Tasks;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Blazor.Client.ClientService
{
    public interface IClientRepository<TDto>
        where TDto : class, IBaseDto, new()
    {
        public string ControllerName { get; set; }
        Task<SingleResponse<TDto>> DeleteAsync(string Id);
        Task<ListResponse<TDto>> GetAllAsync();
        Task<SingleResponse<TDto>> GetByIdAsync(string Id);
        Task<SingleResponse<TDto>> PostAsync(TDto createdObject);
        Task<SingleResponse<TDto>> PutAsync(string Id, TDto updatedObject);
    }
}
