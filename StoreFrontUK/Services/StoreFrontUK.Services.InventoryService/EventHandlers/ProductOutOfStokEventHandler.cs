using StoreFrontUK.HttpClients;
using StoreFrontUK.Messaging;
using StoreFrontUK.Messaging.Events;
using StoreFrontUK.Messaging.Interfaces;
using StoreFrontUK.Services.InventoryService.Repostories;

namespace StoreFrontUK.Services.InventoryService.EventHandlers;

public class ProductOutOfStockEventHandler : IAsyncEventProcessor<ProductOutOfStockEvent>
{
    private readonly EmailServiceClient _emailServiceClient;

    private readonly IProductRepository _productRepository;

    public ProductOutOfStockEventHandler(EmailServiceClient emailServiceClient, IProductRepository productRepository)
    {
        _emailServiceClient = emailServiceClient;
        _productRepository = productRepository;
    }

    public async Task Execute(ProductOutOfStockEvent productOutOfStockEvent)
    {
        var product = await _productRepository.GetById(productOutOfStockEvent.Sku, p => p.Sku);
        if (product is {CanReorder: true})
        {
            await _emailServiceClient.SendProductOutOfStockEmail(productOutOfStockEvent.Sku);
            await RabbitMQService.Instance.AcceptMessage(productOutOfStockEvent.DeliveryTag);
        }
        else
        {
            await RabbitMQService.Instance.RejectMessage(productOutOfStockEvent.DeliveryTag);
        }
        
        await Task.CompletedTask;
    }
}