using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Data.DataContext;
using WarehouseSystemAnalyst.Data.Interfaces.Repositories;

namespace WarehouseSystemAnalyst.Data.Implementation.Repositories
{
    public class UnitOfWorkRepository<TContext> : IUnitOfWorkRepository<TContext>, IDisposable
        where TContext : DbContext, new()
    {
        private bool _disposed;
        private IDbContextTransaction _objTransaction;

        public UnitOfWorkRepository()
        {
            Context = new TContext();
        }

        public UnitOfWorkRepository(TContext context)
        {
            Context = context;
        }


        public TContext Context { get; set; }

        public async Task CommitAsync() => await _objTransaction.CommitAsync();

        public async Task CreateTransactionAsync() => _objTransaction = await Context.Database.BeginTransactionAsync();

        public async void Dispose()
        {
            await Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual async Task Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                await Context.DisposeAsync();

            _disposed = true;
        }

        public async Task RollbackAsync()
        {
            await _objTransaction.RollbackAsync();
            await _objTransaction.DisposeAsync();
        }

        public async Task SaveChangesAsync() => await Context.SaveChangesAsync();
    }
}