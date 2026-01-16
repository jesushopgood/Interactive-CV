using StoreFrontUK.Messaging.Events;
using StoreFrontUK.Messaging.Interfaces;

namespace StoreFrontUK.Services.ThirdParty.JunkFactory.Events;

public class JunkFactoryStockEvent : BaseThirdPartyEvent, IAsyncEvent
{
   
    public async Task ExecuteAsync(IMessageDispatcher messageDispatcher)
    {
        await messageDispatcher.DispatchAsync(this);
    }
}