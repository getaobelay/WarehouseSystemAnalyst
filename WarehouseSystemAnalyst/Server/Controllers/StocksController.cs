using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Models.Dtos.InventoryDtos;
using WarehouseSystemAnalyst.Mediator.Interfaces.Base;
using WarehouseSystemAnalyst.Server.BaseContollers;
using WarehouseSystemAnalyst.Server.Interfaces.Controllers;
using WarehouseSystemAnalyst.Mediator.Requests;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Mediator.Dtos.InventoryDtos;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;

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