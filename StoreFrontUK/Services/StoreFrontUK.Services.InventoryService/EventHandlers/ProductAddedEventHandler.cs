using StoreFrontUK.Services.InventoryService.Data;
using StoreFrontUK.Messaging;
using StoreFrontUK.Messaging.Events;
using StoreFrontUK.Messaging.Interfaces;

namespace StoreFrontUK.Services.InventoryService.EventHandlers;

public class ProductAddedEventHandler : IAsyncEventProcessor<ProductAddedEvent>
{
    private readonly InventoryDbContext _productDbContext;

    public ProductAddedEventHandler(InventoryDbContext productDbContext)
    {
        _productDbContext = productDbContext;
    }

    public async Task Execute(ProductAddedEvent notification)
    {
        var sku = notification.RequestedSku;
        var quantity = notification.RequestedQuantity;

        var inventoryItem = _productDbContext.InventoryItems.Find(sku);

        if (inventoryItem is null)
        {
            await RabbitMQService.Instance.RejectMessage(notification.DeliveryTag);
            return;    
        }
            
        if (inventoryItem.StockLevel < quantity)
            await RabbitMQService.Instance.PublishAsync(new ProductOutOfStockEvent { Sku = sku });
        else
            inventoryItem.StockLevel -= quantity;    
        
        await Task.CompletedTask;
    }
}
