using StoreFrontUK.Messaging.Events;

namespace StoreFrontUK.Messaging.Interfaces;

public interface IMessageDispatcher 
{
    Task DispatchAsync<T>(T item) where T : BaseEvent, IAsyncEvent;
}