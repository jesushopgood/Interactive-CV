using StoreFrontUK.Messaging.Events;
using StoreFrontUK.Messaging.Interfaces;

namespace StoreFrontUK.Services.ThirdParty.BertsBits.Events;

public class BertsBitsStockEvent : BaseThirdPartyEvent, IAsyncEvent
{
    public async Task ExecuteAsync(IMessageDispatcher dispatcher)
    {
        await dispatcher.DispatchAsync(this);
    }
}