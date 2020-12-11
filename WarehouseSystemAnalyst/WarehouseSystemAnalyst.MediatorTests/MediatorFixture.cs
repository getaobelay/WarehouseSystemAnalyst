using MediatR;
using Moq;
using System;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Mediator.loC;

namespace WarehouseSystemAnalyst.MediatorTests
{
    public class FakeMediator
    {
        public virtual IMediator mediator { get; set; }

        public FakeMediator()
        {
            mediator = MediatorContainer.BuildMediator();
        }

    }

    public class MediatorFixture : IDisposable
    {
        public  MockRepository mockRepository;
        private IMediator mediator;
        private Mock<FakeMediator> mockMediator;
        private FakeMediator FakeMediator;
        public MediatorFixture()
        {
            FakeMediator = new FakeMediator();
            mockRepository = new MockRepository(MockBehavior.Loose);
            mockMediator = mockRepository.Create<FakeMediator>();
            mediator = FakeMediator.mediator;

            mockMediator.Object.mediator = mediator;
            Mediator = mockMediator;
        }

        public Mock<FakeMediator> Mediator { get => mockMediator; set { } }
        public void Dispose()
        {
            GC.SuppressFinalize(mockMediator);
        }
    }
}
