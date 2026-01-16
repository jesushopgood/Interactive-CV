using StoreFrontUK.Messaging.Interfaces;

namespace StoreFrontUK.Messaging.Events;

public class ProductAddedEvent : BaseEvent, IAsyncEvent
{
    public string RequestedSku { get; set; } = string.Empty;

    public int RequestedQuantity { get; set; }


    public async Task ExecuteAsync(IMessageDispatcher messageDispatcher)
    {
        await messageDispatcher.DispatchAsync(this);
    }
}