using StoreFrontUK.Messaging;
using StoreFrontUK.Messaging.Interfaces;
using StoreFrontUK.Services.ThirdParty.UncleNobbies.Events;

namespace StoreFrontUK.Services.ThirdParty.UncleNobbies.EventHandlers;

public class UncleNobbiesStockEventHandler : IAsyncEventProcessor<UncleNobbiesStockEvent>
{
    public async Task Execute(UncleNobbiesStockEvent uncleNobbiesStockEvent)
    {
        await RabbitMQService.Instance.AcceptMessage(uncleNobbiesStockEvent.DeliveryTag);
    }
}