using FluentAssertions;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using Xunit;

namespace WarehouseSystemAnalyst.DataTests.Implementation.Repositories
{
    public class WarehouseRepositoryTests : BaseRespositoryTest
    {


        public WarehouseRepository<GoodsWarehouse> GetWarehouseRepository(string database)
        {
            return new WarehouseRepository<GoodsWarehouse>(GetUnitOfWork(database));

        }

        [Fact]
        public async Task MoveWarehouseItem_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var warehouseRepository = GetWarehouseRepository(nameof(MoveWarehouseItem_StateUnderTest_ExpectedBehavior));
            object Id = 1;
            WarehouseItem item = new WarehouseItem();

            // Act
            var result = await warehouseRepository.MoveWarehouseItem(
                Id,
                item);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task ReturnAlloactionItem_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var warehouseRepository = GetWarehouseRepository(nameof(ReturnAlloactionItem_StateUnderTest_ExpectedBehavior));
            object Id = null;
            WarehouseItem warehouseItems = null;

            // Act
            var result = await warehouseRepository.ReturnAlloactionItem(
                Id,
                warehouseItems);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task ReturnWarehouseItem_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var warehouseRepository = GetWarehouseRepository(nameof(ReturnWarehouseItem_StateUnderTest_ExpectedBehavior));
            object Id = null;
            WarehouseItem item = null;

            // Act
            var result = await warehouseRepository.ReturnWarehouseItem(
                Id,
                item);

            // Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdateAlloaction_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var warehouseRepository = GetWarehouseRepository(nameof(UpdateAlloaction_StateUnderTest_ExpectedBehavior));
            object Id = null;
            Allocation allocation = null;

            // Act
            var result = await warehouseRepository.UpdateAlloaction(
                Id,
                allocation);

            // Assert
            result.Should().NotBeNull();
        }
    }
}
