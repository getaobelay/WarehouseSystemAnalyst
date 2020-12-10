using Xunit;
using System.Threading.Tasks;
using Xunit.Priority;
using FluentAssertions;
using WarehouseSystemAnalyst.Mediator.Dtos.InventoryDtos;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Mediator.Commands.Requests.CommonRequests;
using Moq;
using WarehouseSystemAnalyst.Mediator.Commands.Responses.CommonResponses;

namespace WarehouseSystemAnalyst.MediatorTests.Commands.Handlers
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class GenericCommandHandlerTests : IClassFixture<MediatorFixture>
    {

        private MediatorFixture FakeMediator;

        public GenericCommandHandlerTests(MediatorFixture mediatorFixture)
        {
            FakeMediator = mediatorFixture;
        }

        [Fact]
        public async Task CreateCommandTest_ShouldReturnCommandExecuted_WhenCreated()
        {
            InventoryDto inventory = new InventoryDto() { PK = "12", Name = "test" };
            var excpted = CommandResponse.CommandExecuted(message: "Recored Created", inventory);

            var query = new CreateCommandRequest<Inventory, InventoryDto>()
            {
                Entity = inventory,
            };

            FakeMediator.Mediator.Setup(c => c.mediator.Send(query, default)).ReturnsAsync(excpted);

            var result = await FakeMediator.Mediator.Object.mediator.Send(query);

            result.Dto.Should().NotBeNull();
            result.Dto.Name.Should().BeEquivalentTo(inventory.Name);
            result.Error.Should().BeFalse();
            result.ErrorMessages.Should().BeEquivalentTo("Recored Created");

        }

        [Fact]
        public async Task CreateCommandTest_ShouldReturnCommandFailed_WhenFailedCreated()
        {
            InventoryDto inventory = new InventoryDto() { PK = "12" };
            var excpted = CommandResponse.CommandFailed<InventoryDto>(message: "Failed to insert record into the database");

            var query = new CreateCommandRequest<Inventory, InventoryDto>()
            {
                Entity = inventory,
            };

            FakeMediator.Mediator.Setup(c => c.mediator.Send(query, default)).ReturnsAsync(excpted);

            var result = await FakeMediator.Mediator.Object.mediator.Send(query);

            result.Dto.Should().BeNull();
            result.Error.Should().BeTrue();
            result.ErrorMessages.Should().BeEquivalentTo(excpted.ErrorMessages);

        }

        [Fact]
        public async Task UpdateCommandTest_ShouldReturnCommandExecuted_WhenExecutedUpdate()
        {
            InventoryDto inventory = new InventoryDto() { PK = "12" };
            var excpted = CommandResponse.CommandFailed<InventoryDto>(message: "Failed to insert record into the database");

            var query = new CreateCommandRequest<Inventory, InventoryDto>()
            {
                Entity = inventory,
            };

            FakeMediator.Mediator.Setup(c => c.mediator.Send(query, default)).ReturnsAsync(excpted);

            var result = await FakeMediator.Mediator.Object.mediator.Send(query);

            result.Dto.Should().BeNull();
            result.Error.Should().BeTrue();
            result.ErrorMessages.Should().BeEquivalentTo(excpted.ErrorMessages);

        }

        [Fact]
        public async Task UpdateCommandTest_ShouldReturnCommandExecuted_WhenFailedToUpdate()
        {
            InventoryDto inventory = new InventoryDto() { PK = "12" };
            var excpted = CommandResponse.CommandFailed<InventoryDto>(message: "Failed to insert record into the database");

            var query = new CreateCommandRequest<Inventory, InventoryDto>()
            {
                Entity = inventory,
            };

            FakeMediator.Mediator.Setup(c => c.mediator.Send(query, default)).ReturnsAsync(excpted);

            var result = await FakeMediator.Mediator.Object.mediator.Send(query);

            result.Dto.Should().BeNull();
            result.Error.Should().BeTrue();
            result.ErrorMessages.Should().BeEquivalentTo(excpted.ErrorMessages);

        }

        [Fact]
        public async Task DeleteCommandTest_ShouldReturnCommandFailed_WhenExecutedDelete()
        {
            InventoryDto inventory = new InventoryDto() { PK = "12" };
            var excpted = CommandResponse.CommandFailed<InventoryDto>(message: "Failed to insert record into the database");

            var query = new CreateCommandRequest<Inventory, InventoryDto>()
            {
                Entity = inventory,
            };

            FakeMediator.Mediator.Setup(c => c.mediator.Send(query, default)).ReturnsAsync(excpted);

            var result = await FakeMediator.Mediator.Object.mediator.Send(query);

            result.Dto.Should().BeNull();
            result.Error.Should().BeTrue();
            result.ErrorMessages.Should().BeEquivalentTo(excpted.ErrorMessages);

        }

        [Fact]
        public async Task DeleteCommandTest_ShouldReturnCommandExecuted_WhenFailedToDelete()
        {
            InventoryDto inventory = new InventoryDto() { PK = "12" };
            var excpted = CommandResponse.CommandFailed<InventoryDto>(message: "Failed to insert record into the database");

            var query = new CreateCommandRequest<Inventory, InventoryDto>()
            {
                Entity = inventory,
            };

            FakeMediator.Mediator.Setup(c => c.mediator.Send(query, default)).ReturnsAsync(excpted);

            var result = await FakeMediator.Mediator.Object.mediator.Send(query);

            result.Dto.Should().BeNull();
            result.Error.Should().BeTrue();
            result.ErrorMessages.Should().BeEquivalentTo(excpted.ErrorMessages);

        }


    }

}