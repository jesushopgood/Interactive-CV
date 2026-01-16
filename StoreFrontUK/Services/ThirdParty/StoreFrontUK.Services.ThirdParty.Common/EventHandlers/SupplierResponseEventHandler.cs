using StoreFrontUK.Messaging.Interfaces;
using StoreFrontUK.Services.ThirdParty.Common.Events;

namespace StoreFrontUK.Services.ThirdParty.Common.EventHandlers;

public class SupplierResponseEventHandler : IAsyncEventProcessor<SupplierResponseEvent>
{
    public async Task Execute(SupplierResponseEvent supplierResponseEvent)
    {
        await Task.CompletedTask;
    }
}