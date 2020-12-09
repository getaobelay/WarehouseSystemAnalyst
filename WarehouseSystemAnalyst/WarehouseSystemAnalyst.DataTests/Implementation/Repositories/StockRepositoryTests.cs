using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using Xunit;

namespace WarehouseSystemAnalyst.DataTests.Implementation.Repositories
{
    public class StockRepositoryTests
    {

        public WarehouseDbContext GetWarehouseDbContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<WarehouseDbContext>()
                .UseInMemoryDatabase(databaseName: nameof(StockRepositoryTests))
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            return new WarehouseDbContext(options);

        }

        private TransactionRepository<Inventory, Stock> CreateStockRepository()
        {
            return new TransactionRepository<Inventory, Stock>(new WarehouseDbContext());
        }


        [Fact]
        public async Task CreateInventoryAndStock_ShouldReturnTrue_WhenCreated()
        {
            // Arrange
            var stockRepository = CreateStockRepository();
            object sourceId = "test";
            object destinationId = "test";
            string inventoryName = "test";

            // Act
            var result = await stockRepository.CreateInventoryAndStock(
                sourceId,
                destinationId,
                inventoryName);

            // Assert
            result.source.Should().NotBeNull();
            result.Destination.Should().NotBeNull();
            result.source.Name.Should().BeEquivalentTo(inventoryName);
            result.Destination.Should().BeEquivalentTo(inventoryName);
        }

        [Fact]
        public async Task UpdateQuantity_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stockRepository = CreateStockRepository();
            object sourceId = "test";
            object destinationId = "test";
            int quantity = 0;

            // Act
            var result = await stockRepository.UpdateQuantity(
                sourceId,
                destinationId,
                quantity);

            // Assert
            result.Should().NotBeNull();
        }
    }
}
