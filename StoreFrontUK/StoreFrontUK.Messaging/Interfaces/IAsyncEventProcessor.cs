namespace StoreFrontUK.Messaging.Interfaces;

public interface IAsyncEventProcessor<T>
{
    Task Execute(T t);
}