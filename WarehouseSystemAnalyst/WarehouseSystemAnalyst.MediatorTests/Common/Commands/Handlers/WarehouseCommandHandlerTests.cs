using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Mediator.Helpers;
using MediatR;
using Xunit.Priority;
using WarehouseSystemAnalyst.Mediator.Common.Commands.Requests;
using WarehouseSystemAnalyst.Data.Entities.WarehouseEntites.WarehouseTypes;
using WarehouseSystemAnalyst.Mediator.Dtos.WarehouseDtos;
using FluentAssertions;
using WarehouseSystemAnalyst.Data.Implementation.Repositories;
using WarehouseSystemAnalyst.Data.DataContext;

namespace WarehouseSystemAnalyst.MediatorTests.Common.Commands.Handlers
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class WarehouseCommandHandlerTests : IClassFixture<HandlerTestFixture>
    {

        private HandlerTestFixture TestFixture;
        public WarehouseCommandHandlerTests(HandlerTestFixture testFixture)
        {

            TestFixture = testFixture;
        }

        [Fact, Priority(0)]
        public async Task CreateCommandHandlerTest_ShouldReturnDto_WhenCreated()
        {
            var query = new CreateCommandRequest<GoodsWarehouse, GoodsWarehouseDto>();
            query.Entity = TestFixture.GoodsWarehouseDto;

            var result = await TestFixture.mediator.Send(query);

            result.Dto.Should().NotBeNull();
            result.Dto.PK.Should().BeEquivalentTo(TestFixture.GoodsWarehouseDto.PK);
            result.Error.Should().BeFalse();
            result.ErrorMessages.Should().BeEquivalentTo("Recored Created");

        }

        [Fact, Priority(1)]
        public async Task UpdateCommandHandlerTest_ShouldReturnDto_WhenCreated()
        {
            var query = new UpdateCommandRequest<GoodsWarehouse, GoodsWarehouseDto>();
            var warhouseName = "updateWarhouse";
            query.Id = TestFixture.GoodsWarehouseDto.PK;


            var updated = new GoodsWarehouseDto()
            {
                PK = TestFixture.GoodsWarehouseDto.PK,
                WarehouseName = warhouseName
            };

            query.Entity = updated;
            query.Id = TestFixture.GoodsWarehouseDto.PK;

            var result = await TestFixture.mediator.Send(query);

            result.Should().NotBeNull();
            result.Dto.Should().NotBeNull();
            result.Dto.WarehouseName.Should().BeEquivalentTo(warhouseName);
            result.Error.Should().BeFalse();
            result.ErrorMessages.Should().BeEquivalentTo("Recored Updated");
        }

        [Fact, Priority(2)]
        public async Task DeleteCommandHandlerTest_ShouldReturnTrue_WhenDelete()
        {
            var query = new DeleteCommandRequest<GoodsWarehouse, GoodsWarehouseDto>();
            query.Id = TestFixture.GoodsWarehouseDto.PK;
            var result = await TestFixture.mediator.Send(query);

            result.Should().NotBeNull();
            result.Dto.Should().BeNull();
            result.Error.Should().BeFalse();
            result.ErrorMessages.Should().NotBeEmpty();
        }

    }

}