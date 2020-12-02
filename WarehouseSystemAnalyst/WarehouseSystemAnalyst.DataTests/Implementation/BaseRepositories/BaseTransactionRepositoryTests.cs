using Moq;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;
using WarehouseSystemAnalyst.Data.Implementation.BaseRepositories;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;
using Xunit;

namespace WarehouseSystemAnalyst.DataTests1.Implementation.BaseRepositories
{
    public class BaseTransactionRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<IUnitOfWorkRepository<WarehouseDbContext>> mockUnitOfWorkRepository;

        public MockRepository MockRepository { get => mockRepository; set => mockRepository = value; }

        public BaseTransactionRepositoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockUnitOfWorkRepository = this.mockRepository.Create<IUnitOfWorkRepository<WarehouseDbContext>>();
        }

        private BaseTransactionRepository<GoodsWarehouse, AllocationWarehouse> CreateBaseTransactionRepository()
        {
            return new BaseTransactionRepository<GoodsWarehouse,AllocationWarehouse>(this.mockUnitOfWorkRepository.Object.Context);
        }
        /// <summary>
        /// should
        /// </summary>
        /// <returns></returns>

        [Fact]
        public async Task DeleteAsyncByGivenModelsShouldReturnTrue()
        {
            // Arrange
            var baseTransactionRepository = this.CreateBaseTransactionRepository();
            GoodsWarehouse sourceToDelete = null;
            AllocationWarehouse destensionToDelete = null;

            // Act
            var result = await baseTransactionRepository.DeleteAsync(
                sourceToDelete,
                destensionToDelete);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task DeleteAsyncByGivenIdShouldReturnTrueIfDeleted()
        {
            // Arrange
            var baseTransactionRepository = this.CreateBaseTransactionRepository();
            string sourceId = null;
            string destensionId = null;

            // Act
            var result = await baseTransactionRepository.DeleteAsync(
                sourceId,
                destensionId);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
        /// <summary>
        /// populated
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllAsyncShouldRetrunPopulatedList()
        {
            // Arrange
            var baseTransactionRepository = this.CreateBaseTransactionRepository();

            // Act
            var result = await baseTransactionRepository.GetAllAsync();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task InsertAsyncShouldReturnTrueIfCreated()
        {
            // Arrange
            var baseTransactionRepository = this.CreateBaseTransactionRepository();
            GoodsWarehouse source = null;
            AllocationWarehouse destension = null;

            // Act
            var result = await baseTransactionRepository.InsertAsync(
                source,
                destension);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task UpdateAsyncByGivenModelsShouldReturnTrueIfUpdated()
        {
            // Arrange
            var baseTransactionRepository = this.CreateBaseTransactionRepository();
            GoodsWarehouse source = null;
            AllocationWarehouse destension = null;

            // Act
            var result = await baseTransactionRepository.UpdateAsync(
                source,
                destension);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
        /// <summary>
        /// included properties
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetListQueryShouldReturnPopulatedListWithIncludedProperties()
        {
            // Arrange
            var baseTransactionRepository = this.CreateBaseTransactionRepository();
            Expression<Func<GoodsWarehouse, bool>> sourceFilter = null;
            Expression<Func<AllocationWarehouse, bool>> destFilter = null;
            Func<IQueryable<GoodsWarehouse>, IOrderedQueryable<GoodsWarehouse>> sourceOrderBy = null;
            Func<IQueryable<AllocationWarehouse>, IOrderedQueryable<AllocationWarehouse>> destOrderBy = null;
            string includes = null;

            // Act
            var result = await baseTransactionRepository.GetListQuery(
                sourceFilter,
                destFilter,
                sourceOrderBy,
                destOrderBy,
                includes);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// desteny
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetListQueryShouldReturnSourceObjectPopulatedListWithIncludedProperties()
        {
            // Arrange
            var baseTransactionRepository = this.CreateBaseTransactionRepository();
            Expression<Func<GoodsWarehouse, bool>> filter = null;
            Func<IQueryable<GoodsWarehouse>, IOrderedQueryable<GoodsWarehouse>> orderBy = null;
            string includes = null;

            // Act
            var result = await baseTransactionRepository.GetListQuery(
                filter,
                orderBy,
                includes);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        /// <summary>
        /// target destination
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetListQueryShouldReturnDestinationObjectPopulatedListWithIncludedProperties()
        {
            // Arrange
            var baseTransactionRepository = this.CreateBaseTransactionRepository();
            Expression<Func<AllocationWarehouse, bool>> filter = null;
            Func<IQueryable<AllocationWarehouse>, IOrderedQueryable<AllocationWarehouse>> orderBy = null;
            string includes = null;

            // Act
            var result = await baseTransactionRepository.GetListQuery(
                filter,
                orderBy,
                includes);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetSingleQuery_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var baseTransactionRepository = this.CreateBaseTransactionRepository();
            Expression<Func<GoodsWarehouse, bool>> sourceFilter = null;
            Expression<Func<AllocationWarehouse, bool>> destFilter = null;
            string includes = null;

            // Act
            var result = await baseTransactionRepository.GetSingleQuery(
                sourceFilter,
                destFilter,
                includes);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
