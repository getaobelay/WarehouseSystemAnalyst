using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Entities.ProductEntities;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using WarehouseSystemAnalyst.DataTests1.Models;
using Xunit;
using Xunit.Priority;

namespace WarehouseSystemAnalyst.DataTests.Implementation.Repositories
{

    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class InventoryRepositoryTests
    {
        private MockRepository mockRepository;
        private Mock<IUnitOfWorkRepository<WarehouseDbContext>> mockUnitOfWorkRepository;

        private Product Product = TestModels.Product;
        private Batch Batch = TestModels.Batch;
        private Inventory Inventory = TestModels.Inventory;
        private Stock Stock = TestModels.Stock;

        public InventoryRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Default);

            var serviceProvider = new ServiceCollection()
                          .AddEntityFrameworkInMemoryDatabase()
                          .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<WarehouseDbContext>()
                .UseInMemoryDatabase(databaseName: "testDb")
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            this.mockUnitOfWorkRepository = this.mockRepository.Create<IUnitOfWorkRepository<WarehouseDbContext>>(options);

            mockUnitOfWorkRepository.Setup(c => c.Context).Returns(new WarehouseDbContext(options));
            mockUnitOfWorkRepository.Setup(c => c.CreateTransactionAsync());
            mockUnitOfWorkRepository.Setup(c => c.CommitAsync());
            mockUnitOfWorkRepository.Setup(c => c.RollbackAsync());
            mockUnitOfWorkRepository.Setup(c => c.SaveChangesAsync());
            mockUnitOfWorkRepository.Setup(c => c.Dispose());

        }

        private InventoryRepository<Inventory, Stock> CreateInventoryRepository()
        {
            return new InventoryRepository<Inventory, Stock>(
                mockUnitOfWorkRepository.Object.Context);
        }

        [Fact, Priority(0)]
        public async Task CreateAysnc_ShouldReturnTrue()
        {

            // Arrange
            Product.Batches.Add(Batch);
            Inventory.Products.Add(Product);
            Stock.Products.Add(Product);

            var inventoryRepository = this.CreateInventoryRepository();

            //Act
            var result = await inventoryRepository.InsertAsync(source:Inventory,destination: Stock);

            //Assert
            Assert.NotNull(result.destination);
            Assert.NotNull(result.source);

            this.mockRepository.VerifyAll();
        }


        [Fact, Priority(1)]
        public async Task QuantityAvailability_StateUnderTest_ExpectedBehavior2()
        {
            // Arrange
            var inventoryRepository = this.CreateInventoryRepository();
            string sourceId = Inventory.PK;
            string destinationId = Stock.PK;
            string productId = Product.PK;
            string batchId = Batch.PK;
            int quantity = 20;

            // Act
            var result = await inventoryRepository.QuantityAvailability(
                sourceId,
                destinationId,
                productId,
                batchId,
                quantity);

            // Assert
            Assert.NotNull(result.source);
            Assert.NotNull(result.destination);

            this.mockRepository.VerifyAll();
        }

        [Fact, Priority(2)]
        public async Task UpdateQuantity_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var inventoryRepository = this.CreateInventoryRepository();
            string sourceId = Inventory.PK;
            string destinationId = Stock.PK;
            string productId = Product.PK;
            string batchId = Batch.PK;
            int quantity = 0;

            // Act
            var result = await inventoryRepository.UpdateQuantity(
                sourceId,
                destinationId,
                productId,
                batchId,
                quantity);

            // Assert
            Assert.NotNull(result.source);
            Assert.NotNull(result.destination);
            this.mockRepository.VerifyAll();
        }

        [Fact, Priority(3)]
        public async Task DeleteAsync_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var inventoryRepository = this.CreateInventoryRepository();
            string sourceId = Inventory.PK;
            string destinationId = Stock.PK;

            // Act
            var result = await inventoryRepository.DeleteAsync(sourceId, destinationId);

            // Assert
            Assert.True(result);
            this.mockRepository.VerifyAll();
        }
    }
}