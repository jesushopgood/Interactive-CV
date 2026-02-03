using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using StoreFrontUK.GlobalObjects.Customer;
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

    public virtual async Task Update(Entity entity)
    {
        var entityKey = entity.GetKey();
        var entityToUpdate = _context.Set<Entity>().Find(entityKey);

        if (entityToUpdate is null)
            throw new NotFoundException($"The {entity.GetType().Name} {entityKey} is not found");

        _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);

        //Manual Logging
        await LogChanges(entityToUpdate);
        //Built in Logging
        Console.WriteLine(_context.ChangeTracker.DebugView.LongView);
        await _context.SaveChangesAsync();
    }

    public async Task<Entity> Create(Entity entity)
    {
        var entityKey = entity.GetKey();

        if (_context.Set<Entity>().Find(entity.GetKey()) is not null)
            throw new AlreadyExistsException($"{entity.GetType().Name} {entityKey} already exists! ");
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

        return result;
    }

    protected async Task<IQueryable<Entity>> AppendIncludesAsync(IQueryable<Entity> query, params Expression<Func<Entity, object>>[] includes)
    {
        foreach (var include in includes)
            query = query.Include(include);

        return query;
    }

    protected async Task LogChanges(Entity changedEntity)
    {
        var currentEntityState = _context.Entry(changedEntity).State;

        Console.WriteLine("Changed Properties");
        Console.WriteLine("------------------");
        Console.WriteLine($"Entity State {currentEntityState}");

        var changedProperties = _context.Entry(changedEntity)
            .Properties
            .Where(x => x.IsModified)
            .Select(p => new { p.Metadata.Name, p.OriginalValue, p.CurrentValue })
            .ToList();

        foreach (var item in changedProperties)
        {
            Console.WriteLine($"Name {item.Name} Original Value: {item.OriginalValue} Current Value {item.CurrentValue}");
        }
    }
}