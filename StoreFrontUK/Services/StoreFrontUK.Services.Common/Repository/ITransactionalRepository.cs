namespace StoreFrontUK.Services.Common.Repository;

public interface ITransactionalRepository<Context, Entity, Key> : IRepository<Context, Entity, Key>
{
    Task BeginTransactionAsync(CancellationToken cancellationToken);

    Task RollbackTransactionAsync(CancellationToken cancellationToken);

    Task CommitTransactionAsync(CancellationToken cancellationToken);
}