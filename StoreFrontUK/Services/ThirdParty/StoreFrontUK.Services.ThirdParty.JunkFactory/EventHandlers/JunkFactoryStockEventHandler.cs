using StoreFrontUK.Messaging;
using StoreFrontUK.Messaging.Interfaces;
using StoreFrontUK.Services.ThirdParty.JunkFactory.Events;

namespace StoreFrontUK.Services.ThirdParty.JunkFactory.EventHandlers;

public class JunkFactoryStockEventHandler : IAsyncEventProcessor<JunkFactoryStockEvent>
{
    public async Task Execute(JunkFactoryStockEvent junkFactoryStockEvent)
    {
        await RabbitMQService.Instance.AcceptMessage(junkFactoryStockEvent.DeliveryTag);
    }
}