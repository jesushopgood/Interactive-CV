using StoreFrontUK.Messaging.Events;
using StoreFrontUK.Messaging.Interfaces;

namespace StoreFrontUK.Services.ThirdParty.UncleNobbies.Events;

public class UncleNobbiesStockEvent : BaseThirdPartyEvent, IAsyncEvent
{
    public async Task ExecuteAsync(IMessageDispatcher messageDispatcher)
    {
        await messageDispatcher.DispatchAsync(this);
    }
}