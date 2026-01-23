using Microsoft.EntityFrameworkCore;
using StoreFrontUK.Services.Common.Repository;

namespace StoreFrontUK.Services.Common.Repository;

public class TransactionalRepository<Context, Entity, Key> : Repository<Context, Entity, Key>, ITransactionalRepository<Context, Entity, Key>
                                                                where Entity : class, IEntityWithKey<Key>
                                                                where Context : DbContext
{
    public TransactionalRepository(Context context) : base(context) { }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken) => await _context.Database.BeginTransactionAsync();

    public async Task CommitTransactionAsync(CancellationToken cancellationToken) => await _context.Database.CommitTransactionAsync();

    public Task RollbackTransactionAsync(CancellationToken cancellationToken) => _context.Database.RollbackTransactionAsync();
}