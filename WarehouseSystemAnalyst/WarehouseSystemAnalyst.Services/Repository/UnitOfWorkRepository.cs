using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Interfaces.Repository;

namespace WarehouseSystemAnalyst.Services.Repository
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class UnitOfWorkRepository<TContext> : IUnitOfWorkRepository<TContext>, IDisposable
        where TContext : DbContext, new()
    {
        private bool _disposed;
        private IDbContextTransaction _objTransaction;
        private readonly Dictionary<string, object> _repositories;

        public UnitOfWorkRepository()
        {
            Context = new TContext();
        }

        public TContext Context { get; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync() => await _objTransaction.CommitAsync();
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task RollbackAsync()
        {
            await _objTransaction.RollbackAsync();
            await _objTransaction.DisposeAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task SaveChangesAsync() => await Context.SaveChangesAsync();
    }
}
