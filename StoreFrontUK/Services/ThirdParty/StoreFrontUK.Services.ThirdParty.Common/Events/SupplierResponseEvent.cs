using StoreFrontUK.Messaging.Events;
using StoreFrontUK.Messaging.Interfaces;

namespace StoreFrontUK.Services.ThirdParty.Common.Events;

public class SupplierResponseEvent : BaseThirdPartyEvent, IAsyncEvent
{
    public string SupplierName { get; set; } = string.Empty; 
    public decimal TotalPrice { get; set; }

    public async Task ExecuteAsync(IMessageDispatcher messageDispatcher)
    {
        await messageDispatcher.DispatchAsync(this);
    }
}