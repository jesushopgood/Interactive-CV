namespace StoreFrontUK.Services.Common.Repository;

public interface IEntityWithKey { }
public interface IEntityWithKey<T> : IEntityWithKey
{
    T GetKey();
}