using FluentAssertions;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using Xunit;

namespace WarehouseSystemAnalyst.DataTests.Implementation.Repositories
{
    public class StockRepositoryTests : BaseRespositoryTest
    {

        public StockRepository<Inventory> GetStockRepository(string database)
        {
            return new StockRepository<Inventory>(GetUnitOfWork(database));
        }

        [Fact]
        public async Task ReturnAlloactionItem_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stockRepository = GetStockRepository(nameof(ReturnAlloactionItem_StateUnderTest_ExpectedBehavior));
            object Id = null;
            WarehouseItem warehouseItems = null;

            // Act
            var result = await stockRepository.ReturnAlloactionItem(
                Id,
                warehouseItems);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task ReturnWarehouseItem_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stockRepository = GetStockRepository(nameof(ReturnWarehouseItem_StateUnderTest_ExpectedBehavior));
            object Id = null;
            WarehouseItem warehouseItems = null;

            // Act
            var result = await stockRepository.ReturnWarehouseItem(
                Id,
                warehouseItems);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateAlloaction_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stockRepository = GetStockRepository(nameof(UpdateAlloaction_StateUnderTest_ExpectedBehavior));
            object Id = null;
            Allocation allocation = null;

            // Act
            var result = await stockRepository.UpdateAlloaction(
                Id,
                allocation);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateWarehouseItem_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stockRepository = GetStockRepository(nameof(UpdateWarehouseItem_StateUnderTest_ExpectedBehavior));
            object Id = null;
            WarehouseItem item = null;

            // Act
            var result = await stockRepository.UpdateWarehouseItem(
                Id,
                item);

            // Assert
            result.Should().NotBeNull();
        }
    }
}
