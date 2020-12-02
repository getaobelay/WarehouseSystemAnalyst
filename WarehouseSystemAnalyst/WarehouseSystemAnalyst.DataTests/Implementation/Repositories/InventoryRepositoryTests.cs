using Moq;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.DataTests1.Models;
using Xunit;

namespace WarehouseSystemAnalyst.DataTests.Implementation.Repositories
{
    public class InventoryRepositoryTests
    {
        private MockRepository mockRepository;
        private Inventory Source = TestModels.Inventory;
        private Stock Destination = TestModels.Stock;
        private Mock<IUnitOfWorkRepository<WarehouseDbContext>> mockUnitOfWorkRepository;

        public InventoryRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockUnitOfWorkRepository = this.mockRepository.Create<IUnitOfWorkRepository<WarehouseDbContext>>();
        }

        private InventoryRepository<Inventory, Stock> CreateInventoryRepository()
        {
            return new InventoryRepository<Inventory, Stock>(
                this.mockUnitOfWorkRepository.Object.Context);
        }

        [Fact]
        public async Task SourceQuantityAvailability_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Source.ProductQuantity = 100;
            Source.BatchQuantity = 100;

            var inventoryRepository = this.CreateInventoryRepository();
            string productId = Source.ProductID;
            string batchId = Source.BatchID;
            int Quantity = 10;

            // Act
            var result = await inventoryRepository.SourceQuantityAvailability(
                productId,
                batchId,
                Quantity);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task DestinationQuantityAvailability_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Destination.ProductQuantity = 100;
            Destination.BatchQuantity = 100;

            var inventoryRepository = this.CreateInventoryRepository();
            string productId = Destination.ProductID;
            string batchId = Destination.BatchID;
            int Quantity = 10;

            // Act
            var result = await inventoryRepository.DestinationQuantityAvailability(
                productId,
                batchId,
                Quantity);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task TotalQuantityAvailability_StateUnderTest_ExpectedBehavior()
        {

            // Arrange
            var inventoryRepository = this.CreateInventoryRepository();
            string productId = Source.ProductID;
            string batchId = Source.BatchID;
            int Quantity = 20;

            // Act
            var result = await inventoryRepository.TotalQuantityAvailability(
                productId,
                batchId,
                Quantity);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task MoveQuantityToDestination_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var inventoryRepository = this.CreateInventoryRepository();
            string productId = Source.ProductID;
            string batchId = Source.BatchID;
            int Quantity = 20;

            // Act
            var result = await inventoryRepository.MoveQuantityToDestination<Stock>(
                productId,
                batchId,
                Quantity);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task MoveQuantityToSource_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var inventoryRepository = this.CreateInventoryRepository();
            string productId = Destination.ProductID;
            string batchId = Destination.BatchID;
            int Quantity = 20;

            // Act
            var result = await inventoryRepository.MoveQuantityToSource<Inventory>(
                productId,
                batchId,
                Quantity);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
