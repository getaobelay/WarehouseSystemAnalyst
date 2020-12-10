using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Data.Helpers;
using WarehouseSystemAnalyst.Data.Implementation;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using Xunit;

namespace WarehouseSystemAnalyst.MediatorTests.Implementation
{
    public class TransactionRepositoryTests
    {
        private MockRepository mockRepository;
        public TransactionRepositoryTests()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Mock<TransactionRepository<Inventory, Stock>> CreateTransactionRepository()
        {
            return new Mock<TransactionRepository<Inventory, Stock>>(new WarehouseDbContext());
        }

        [Fact]
        public async Task DeleteAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var transactionRepository = this.CreateTransactionRepository();
            Inventory source = new Inventory() { PK = "a" };
            Stock destination = new Stock() { PK = "b" };

            transactionRepository.Setup(d => d.DeleteAsync(It.IsAny<Inventory>(), It.IsAny<Stock>()))
                .ReturnsAsync(true);

            // Act
            var result = await transactionRepository.Object.DeleteAsync(source, destination);

            // Assert
            result.Should().BeTrue();
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task DeleteAsync_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var transactionRepository = this.CreateTransactionRepository();
            string sourceId = "1";
            string destinationId = "1";
            var expected = TransactionResponse.Success<Inventory, Stock>(null, null);


            transactionRepository.Setup(d => d.DeleteAsync(It.IsAny<object>(), It.IsAny<object>()))
             .ReturnsAsync(expected);

            // Act
            var result = await transactionRepository.Object.DeleteAsync(
                sourceId,
                destinationId);

            // Assert

            result.Source.Should().BeNull();
            result.Destination.Should().BeNull();
            result.ErrorMessages.Should().BeNull();
            mockRepository.VerifyAll();
        }

        [Fact]
        public async Task InsertAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var transactionRepository = this.CreateTransactionRepository();
            Inventory source = new Inventory() { PK = "1" };
            Stock destination = new Stock() { PK = "1" };

            var expected = TransactionResponse.Success(source, destination);

            transactionRepository.Setup(d => d.InsertAsync(It.IsAny<Inventory>(), It.IsAny<Stock>()))
           .ReturnsAsync(expected);


            // Act
            var result = await transactionRepository.Object.InsertAsync(
                source,
                destination);

            // Assert
            result.Source.Should().NotBeNull();
            result.Destination.Should().NotBeNull();
            result.ErrorMessages.Should().BeNull();
            mockRepository.VerifyAll();
        }

        [Fact]
        public async Task UpdateAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var transactionRepository = this.CreateTransactionRepository();

            Inventory source = new Inventory { PK = "1" };
            Stock destination = new Stock { PK = "1" }; ;

            var expected = TransactionResponse.Success(source, destination);

            transactionRepository.Setup(d => d.UpdateAsync(It.IsAny<Inventory>(), It.IsAny<Stock>()))
           .ReturnsAsync(expected);

            // Act
            var result = await transactionRepository.Object.UpdateAsync(
                source,
                destination);

            // Assert
            result.Source.Should().NotBeNull();
            result.Destination.Should().NotBeNull();
            result.ErrorMessages.Should().BeNull();
            mockRepository.VerifyAll();
        }
    }
}
