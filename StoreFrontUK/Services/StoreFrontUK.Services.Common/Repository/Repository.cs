using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StoreFrontUK.Services.Common.Exceptions;

namespace StoreFrontUK.Services.Common.Repository;

public abstract class Repository<Context, Entity, Key> : IRepository<Context, Entity, Key>
                                                        where Entity : class, IEntityWithKey<Key>
                                                        where Context : DbContext
{
    protected readonly Context _context;

    protected Repository(Context context)
    {
        _context = context;
    }

    public Task<bool> Exists(Key id)
    {
        var result = _context.Set<Entity>().Find(id);
        return Task.FromResult(result is not null);
    }

    public async Task<List<Entity>> GetAllAsync(params Expression<Func<Entity, object>>[] includes)
    {
        IQueryable<Entity> query = _context.Set<Entity>().AsNoTracking();
        query = await AppendIncludesAsync(query, includes);
        return await query.ToListAsync();
    }

    public async Task<Entity?> GetByIdAsync(Key id, Expression<Func<Entity, Key>> keySelector)
    {
        IQueryable<Entity> query = _context.Set<Entity>().AsNoTracking();
        return await GetByKey(id, query, keySelector);
    }

    public async Task<Entity?> GetByIdAsync(Key id,
                                        Expression<Func<Entity, Key>> keySelector,
                                        params Expression<Func<Entity, object>>[] includes)
    {
        IQueryable<Entity> query = _context.Set<Entity>().AsNoTracking();
        query = await AppendIncludesAsync(query, includes);

        return await GetByKey(id, query, keySelector);
    }

    public async Task Update(Entity entity)
    {
        var entityKey = entity.GetKey();
        var entityToUpdate = _context.Set<Entity>().Find(entityKey);

        if (entityToUpdate is null)
            throw new NotFoundException($"The {entity.GetType().Name} {entityKey} is not found");

        await _context.SaveChangesAsync();
    }

    public async Task<Entity> Create(Entity entity)
    {
        var entityKey = entity.GetKey();

        if (_context.Set<Entity>().Find(entity.GetKey()) is not null)
            throw new AlreadyExistsException($"{entity.GetType().Name} ${entityKey} already exists! ");

        await _context.Set<Entity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return await Task.FromResult(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    private async Task<Entity?> GetByKey(Key id, IQueryable<Entity> query, Expression<Func<Entity, Key>> keySelector)
    {
        var result = await query.FirstOrDefaultAsync(
            Expression.Lambda<Func<Entity, bool>>(
            Expression.Equal(keySelector.Body, Expression.Constant(id)),
            keySelector.Parameters
        ));

        return await Task.FromResult(result);
    }

    protected async Task<IQueryable<Entity>> AppendIncludesAsync(IQueryable<Entity> query, params Expression<Func<Entity, object>>[] includes)
    {
        foreach (var include in includes)
            query = query.Include(include);

        return query;
    }
}