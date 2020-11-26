//using MediatR;
//using System.Threading;
//using System.Threading.Tasks;
//using System;
//using WarehouseControl.Implementation.Repositories;
//using WarehouseControl.Data.Context;
//using WarehouseControl.Commands.Requests;

//namespace WarehouseControl.Commands.Handlers
//{

//    /// <summary>
//    ///
//    /// </summary>
//    /// <typeparam name="TSource"></typeparam>
//    /// <typeparam name="TCommand"></typeparam>
//    public class MoveQuantityCommandHandler<TSource, TDestension, TCommand> : IRequestHandler<TCommand, bool>
//      where TSource : class, new()
//      where TDestension : class, new()
//      where TCommand : class, IMoveQuantityCommand<TSource, TDestension>, new()
//    {
//        private readonly UnitOfWork<WarehouseDbContext> unitOfWork = new UnitOfWork<WarehouseDbContext>();
//        private readonly InventoryRepository<TSource> inventoryRepository;
//        public MoveQuantityCommandHandler()
//        {
//            inventoryRepository = new InventoryRepository<TSource>(unitOfWork);
//        }

//        public async Task<bool> Handle(TCommand request, CancellationToken cancellationToken)
//        {
//            try
//            {
//                await inventoryRepository.MoveQuantity<TDestension>(request.Quantity, request.expression);
//                await unitOfWork.SaveChangesAsync();
//                return true;
//            }
//            catch (Exception)
//            {
//                throw;
//            }

//        }
//    }
//}
