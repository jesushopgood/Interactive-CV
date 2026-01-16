namespace StoreFrontUK.Messaging.Interfaces;

public interface IAsyncEvent
{
    ulong DeliveryTag { get; set; }

    Task ExecuteAsync(IMessageDispatcher messageDispatcher);
}