using FluentAssertions;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.Entities.StockEntites;
using WarehouseSystemAnalyst.Mediator.Commands.Requests.CommonRequests;
using WarehouseSystemAnalyst.Mediator.Commands.Responses.CommonResponses;
using WarehouseSystemAnalyst.Mediator.Dtos.InventoryDtos;
using Xunit;

namespace WarehouseSystemAnalyst.MediatorTests.Commands.Validation
{
    public class CommonCommandValidationTests : IClassFixture<MediatorFixture>
    {
        private readonly MediatorFixture _fakeMediator;
        private readonly IValidator validator;

        public CommonCommandValidationTests(MediatorFixture FakeMediator)
        {
            _fakeMediator = FakeMediator;
        }

        [Fact]
        public async Task CreateCommandValidatorTest_ShouldNotThrowValidaitonException_WhenEntitySet()
        {
            var command = new CreateCommandRequest<Inventory, InventoryDto>()
            {
                CreateObject = new InventoryDto() { PK = "1" }
            };

            _fakeMediator.Mediator.Setup(c => c.mediator.Send(command, default))
                .ReturnsAsync(It.IsAny<CommandResponse<InventoryDto>>);

            await FluentActions.Invoking(() => _fakeMediator.Mediator.Object.mediator.Send(command))
                   .Should().NotThrowAsync<ValidationException>();

            _fakeMediator.mockRepository.VerifyAll();
        }



        [Fact]
        public async Task CreateCommandValidatorTest_ShouldThrowValidationException_WhenEntityNotSet()
        {
            var command = new CreateCommandRequest<Inventory, InventoryDto>();

            _fakeMediator.Mediator.Setup(c => c.mediator.Send(command, default))
               .ReturnsAsync(It.IsAny<CommandResponse<InventoryDto>>())
               .Verifiable();

            await FluentActions.Invoking(() => _fakeMediator.Mediator.Object.mediator.Send(command)).Should()
                .ThrowAsync<ValidationException>();

            _fakeMediator.Mediator.Verify(x => x.mediator.Send(command, default));

        }


        [Fact]
        public async Task CreateCommandValidatorTest_ShouldThrowValidationException_WhenEntityIdNotSet()
        {
            var command = new CreateCommandRequest<Inventory, InventoryDto>()
            {
                CreateObject = new InventoryDto()
            };

            _fakeMediator.Mediator.Setup(c => c.mediator.Send(command, default))
                .ReturnsAsync(It.IsAny<CommandResponse<InventoryDto>>());

            await FluentActions.Invoking(() => _fakeMediator.Mediator.Object.mediator.Send(command))
                    .Should().ThrowAsync<ValidationException>();
        }


        [Fact]
        public async Task UpdateCommandValidatorTest_ShouldThrowValidationException_WhenEntityNotSet()
        {
            var command = new UpdateCommandRequest<Inventory, InventoryDto>();

            _fakeMediator.Mediator.Setup(c => c.mediator.Send(command, default))
                .ReturnsAsync(It.IsAny<CommandResponse<InventoryDto>>());

            await FluentActions.Invoking(() => _fakeMediator.Mediator.Object.mediator.Send(command))
                    .Should().ThrowAsync<ValidationException>();
        }


        [Fact]
        public async Task UpdateCommandValidatorTest_ShouldNotThrowValidationException_WhenEntitySet()
        {
            var command = new UpdateCommandRequest<Inventory, InventoryDto>()
            {
                UpdatedObject = new InventoryDto() { PK = "2" },
                Id = "2"
            };

            _fakeMediator.Mediator.Setup(c => c.mediator.Send(command, default))
                .ReturnsAsync(It.IsAny<CommandResponse<InventoryDto>>());

            await FluentActions.Invoking(() => _fakeMediator.Mediator.Object.mediator.Send(command))
                 .Should().NotThrowAsync<ValidationException>();
        }



        [Fact]
        public async Task DeleteCommandValidatorTest_ShouldThrowValidationException_WhenIdNotSet()
        {
            var command = new DeleteCommandRequest<Inventory, InventoryDto>();

            _fakeMediator.Mediator.Setup(c => c.mediator.Send(command, default))
                .ReturnsAsync(It.IsAny<CommandResponse<InventoryDto>>());

            await FluentActions.Invoking(() => _fakeMediator.Mediator.Object.mediator.Send(command))
                    .Should().ThrowAsync<ValidationException>();
        }


        [Fact]
        public async Task DeleteCommandValidatorTest_ShouldNotThrowValidationException_WhenIdSet()
        {
            var command = new DeleteCommandRequest<Inventory, InventoryDto>()
            {
                Id = "2"
            };

            _fakeMediator.Mediator.Setup(c => c.mediator.Send(command, default))
                .ReturnsAsync(It.IsAny<CommandResponse<InventoryDto>>());

            await FluentActions.Invoking(() => _fakeMediator.Mediator.Object.mediator.Send(command))
                    .Should().NotThrowAsync<ValidationException>();
        }



    }
}
