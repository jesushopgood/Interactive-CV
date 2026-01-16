namespace StoreFrontUK.Services.Common.Repository;

public interface IHasKey<T>
{
    T GetKey();
}