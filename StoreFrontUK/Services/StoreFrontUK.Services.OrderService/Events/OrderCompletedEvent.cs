using StoreFrontUK.Messaging.Events;
using StoreFrontUK.Messaging.Interfaces;

namespace StoreFrontUK.Services.OrderService.Events;

public class OrderCompletedEvent : BaseEvent, IAsyncEvent
{
    public long OrderId { get; set; }

    public string CustomerId { get; set; } = string.Empty;

    public string EmailAddress { get; set; } = string.Empty;

    public async Task ExecuteAsync(IMessageDispatcher messageDispatcher)
    {
        await messageDispatcher.DispatchAsync(this);
    }
}