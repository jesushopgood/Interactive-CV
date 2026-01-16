using AutoMapper;
using StoreFrontUK.Messaging;
using StoreFrontUK.Messaging.Interfaces;
using StoreFrontUK.Services.ThirdParty.BertsBits.Data;
using StoreFrontUK.Services.ThirdParty.BertsBits.Events;
using StoreFrontUK.Services.ThirdParty.Common.Events;

namespace StoreFrontUK.Services.ThirdParty.BertsBits.EventHandlers;

public class BertsBitsStockEventHandler : IAsyncEventProcessor<BertsBitsStockEvent>
{
    private readonly BertsBitsDbContext _bertsBitsDbContext;
    private readonly IMapper _mapper;

    public BertsBitsStockEventHandler(BertsBitsDbContext bertsBitsDbContext, IMapper mapper)
    {
        _bertsBitsDbContext = bertsBitsDbContext;
        _mapper = mapper;
    }

    public async Task Execute(BertsBitsStockEvent bertsBitsStockEvent)
    {
        await RabbitMQService.Instance.AcceptMessage(bertsBitsStockEvent.DeliveryTag);

        var response = await PrepareResponse(bertsBitsStockEvent);
        if (response.Item2)
            await RabbitMQService.Instance.PublishAsync(response.Item1);
    }

    private async Task<(SupplierResponseEvent, bool)> PrepareResponse(BertsBitsStockEvent bertsBitsStockEvent)
    {
        var supplierResponseEvent = new SupplierResponseEvent
        {
            OrderId = bertsBitsStockEvent.OrderId,
            Deadline = bertsBitsStockEvent.Deadline
        };

        var stockItems = _bertsBitsDbContext.StockItems;
        var requestedItems = bertsBitsStockEvent.Items;
        var success = true;

        requestedItems.ForEach(async requestedItem =>
        {
            var stockItem = stockItems.FirstOrDefault(si => si.Sku == requestedItem.Sku);
            if (stockItem != null && stockItem.StockLevel >= requestedItem.Quantity)
            {
                stockItem.StockLevel -= requestedItem.Quantity;
                supplierResponseEvent.Items.Add(requestedItem);
            }
            else
                success = false;
        });


        await _bertsBitsDbContext.SaveChangesAsync();
        return await Task.FromResult((supplierResponseEvent, success));
    } 
}