using Xunit;
using System.Threading.Tasks;
using Xunit.Priority;
using FluentAssertions;
using WarehouseSystemAnalyst.Mediator.Dtos.InventoryDtos;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Mediator.Commands.Requests.CommonRequests;

namespace WarehouseSystemAnalyst.MediatorTests.Common.Commands.Handlers
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class InventoryCommandHandlerTests : IClassFixture<HandlerTestFixture>
    {

        private HandlerTestFixture TestFixture;


        public InventoryCommandHandlerTests(HandlerTestFixture testFixture)
        {

            TestFixture = testFixture;

        }

        [Fact, Priority(0)]
        public async Task CreateCommandHandlerTest_ShouldReturnDto_WhenCreated()
        {

            var query = new CreateCommandRequest<Inventory, InventoryDto>()
            {
                Entity = TestFixture.InventoryDto,
            };

            var result = await TestFixture.mediator.Send(query);

            result.Dto.Should().NotBeNull();
            result.Dto.PK.Should().BeEquivalentTo(TestFixture.InventoryDto.PK);
            result.Error.Should().BeFalse();
            result.ErrorMessages.Should().BeEquivalentTo("Recored Created");

        }

        [Fact, Priority(1)]
        public async Task UpdateCommandHandlerTest_ShouldReturnDto_WhenCreated()
        {
            var warhouseName = "updateWarhouse";

            var query = new UpdateCommandRequest<Inventory, InventoryDto>()
            {
                Id = TestFixture.InventoryDto.PK,
                Entity = new InventoryDto()
                {
                    PK = TestFixture.InventoryDto.PK,
                    Name = warhouseName,
                    ProductQuantity = 12,
                    BatchQuantity = 12,
                    UnitsInOrder = 21,
                    TotalUnitsQuantity = 21,
                    ReorderLevel = 12,
                    UnitsInInventory = 12
                }
            };


            var result = await TestFixture.mediator.Send(query);

            result.Should().NotBeNull();
            result.Dto.Should().NotBeNull();
            result.Dto.Name.Should().BeEquivalentTo(warhouseName);
            result.Error.Should().BeFalse();
            result.ErrorMessages.Should().BeEquivalentTo("Recored Updated");
        }

        [Fact, Priority(2)]
        public async Task DeleteCommandHandlerTest_ShouldReturnTrue_WhenDelete()
        {
            var query = new DeleteCommandRequest<Inventory, InventoryDto>()
            {
                Id = TestFixture.InventoryDto.PK
            };

            var result = await TestFixture.mediator.Send(query);

            result.Should().NotBeNull();
            result.Dto.Should().BeNull();
            result.Error.Should().BeFalse();
            result.ErrorMessages.Should().NotBeEmpty();
        }

    }

}