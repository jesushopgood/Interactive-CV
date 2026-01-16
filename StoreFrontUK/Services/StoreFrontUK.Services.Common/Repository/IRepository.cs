using System.Linq.Expressions;

namespace StoreFrontUK.Services.Common.Repository;

public interface IRepository<Context, Entity, Key>
{
    Task<List<Entity>> GetAll(params Expression<Func<Entity, object>>[] includes);

    Task<Entity?> GetById(Key id, Expression<Func<Entity, Key>> keySelector);

    Task<Entity?> GetById(Key id,
                            Expression<Func<Entity, Key>> keySelector,
                            Expression<Func<Entity, object>>[] includes);

    Task<bool> Exists(Key id);

    Task<Entity> Create(Entity entity);

    Task Update(Entity entity);

    Task SaveChangesAsync();
}