using Microsoft.AspNetCore.Mvc;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Server.BaseContollers;
using WarehouseSystemAnalyst.Server.Interfaces.Controllers;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Mediator.Dtos.InventoryDtos;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Mediator.Common.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WarehouseSystemAnalyst.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : BaseController<Stock, StockDto, BaseResponse<StockDto>, BaseRequest<Stock, StockDto>>,
        IIStockController<Stock, StockDto, BaseResponse<StockDto>, BaseRequest<Stock, StockDto>>
    {
        protected StocksController() : base()
        {
        }

        protected StocksController(DataRepository<Stock> repository) : base(repository)
        {
        }

        public Task<ActionResult<BaseResponse<StockDto>>> ReturnAllocatedQuanityAsync(object Id, int quanity)
        {
            throw new System.NotImplementedException();
        }
        public Task<ActionResult<BaseResponse<StockDto>>> UpdateAlloaction(object Id)
        {
            throw new System.NotImplementedException();
        }
        public Task<ActionResult<BaseResponse<StockDto>>> UpdateAllocatedQuanityAsync(object Id, int quanity)
        {
            throw new System.NotImplementedException();
        }
    }
}