using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Mediator.Dtos;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;
using WarehouseSystemAnalyst.Server.BaseContollers;

namespace WarehouseSystemAnalyst.Server.Interfaces
{
    public interface IAPIController<TDto>
        where TDto : class, IBaseDto, new()
    {
        Task<ActionResult<IBaseResponse<TDto>>> DeleteAsync(string Id);
        Task<ActionResult<IBaseResponse<TDto>>> GetAllAsync();
        Task<ActionResult<IBaseResponse<TDto>>> GetByIdAsync(string Id);
        Task<ActionResult<IBaseResponse<TDto>>> PostAsync(ProductDto createdObject);
        Task<ActionResult<IBaseResponse<TDto>>> PutAsync(string Id, ProductDto updatedObject);
    }
}