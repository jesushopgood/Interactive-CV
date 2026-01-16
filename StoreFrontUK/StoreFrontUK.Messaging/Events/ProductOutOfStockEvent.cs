using StoreFrontUK.Messaging.Interfaces;

namespace StoreFrontUK.Messaging.Events;

public class ProductOutOfStockEvent : BaseEvent, IAsyncEvent
{
    public string Sku { get; set; } = string.Empty;

    public async Task ExecuteAsync(IMessageDispatcher messageDispatcher)
    {
        await messageDispatcher.DispatchAsync(this);
    }
}