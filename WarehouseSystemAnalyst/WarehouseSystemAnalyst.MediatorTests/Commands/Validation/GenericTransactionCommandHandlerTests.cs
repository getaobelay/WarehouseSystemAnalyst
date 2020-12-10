using Xunit;
using System.Threading.Tasks;
using Xunit.Priority;
using FluentAssertions;

namespace WarehouseSystemAnalyst.MediatorTests.Commands.Handlers
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class GenericTransactionCommandHandlerTests : IClassFixture<MediatorFixture>
    {
        private readonly MediatorFixture _fakeMediator;

        public GenericTransactionCommandHandlerTests(MediatorFixture FakeMediator)
        {
            _fakeMediator = FakeMediator;
        }
    }

}