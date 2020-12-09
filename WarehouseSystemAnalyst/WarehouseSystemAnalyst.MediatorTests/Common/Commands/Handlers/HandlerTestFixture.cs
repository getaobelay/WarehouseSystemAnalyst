using Autofac;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Entities.BaseEntites;
using WarehouseSystemAnalyst.Data.Implementation;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.Mediator.Containers;
using WarehouseSystemAnalyst.Mediator.Dtos.InventoryDtos;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;

namespace WarehouseSystemAnalyst.MediatorTests.Common.Commands.Handlers
{
    public class HandlerTestFixture : IDisposable
    {
        public IMediator mediator { get; set; }
        public GoodsWarehouseDto GoodsWarehouseDto;
        public InventoryDto InventoryDto;
        public HandlerTestFixture()
        {
            GoodsWarehouseDto = new GoodsWarehouseDto();
            InventoryDto = new InventoryDto();
            GoodsWarehouseDto.PK = Guid.NewGuid().ToString();
            GoodsWarehouseDto.WarehouseName = "WarehouseName";

            InventoryDto.PK = Guid.NewGuid().ToString();
            InventoryDto.ProductQuantity = 1;
            InventoryDto.BatchQuantity = 1;
            InventoryDto.UnitsInOrder = 1;
            InventoryDto.TotalUnitsQuantity = 10;
            InventoryDto.ReorderLevel = 1;
            InventoryDto.UnitsInInventory = 1;

            mediator = MediatorContainer.BuildMediator();
        }

        public void Dispose()
        {
            mediator = MediatorContainer.BuildMediator();
        }

        public static DataRepository<TEntity> GetDataRepository<TEntity>(IUnitOfWorkRepository<WarehouseDbContext> unitOfWork)
            where TEntity : class, IBaseEntity, new()
        {
            return new DataRepository<TEntity>(unitOfWork);
        }
    }
}
