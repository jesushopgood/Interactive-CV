using StoreFrontUK.Messaging;
using StoreFrontUK.HttpClients;
using StoreFrontUK.Services.PickService.Requests;
using AutoMapper;
using StoreFrontUK.GlobalObjects.PickService.Responses;
using StoreFrontUK.Messaging.Events;

namespace StoreFrontUK.Services.PickService;

public class PickService : IPickService
{
    private readonly InventoryServiceClient _inventoryServiceClient;
    private readonly IMapper _mapper;

    public PickService(InventoryServiceClient inventoryServiceClient,
                        IMapper mapper)
    {
        _inventoryServiceClient = inventoryServiceClient;
        _mapper = mapper;
    }

    public async Task<PickOrderResponse> PickAsync(PickOrderRequest pickOrderRequest)
    {
        return await _inventoryServiceClient.PickProducts(pickOrderRequest.Items);
    }

    public async Task PickExternalAsync(PickOrderRequest pickOrderRequest, PickOrderResponse pickOrderResponse)
    {
        pickOrderRequest.Items.ForEach(item =>
        {
            item.Quantity -= pickOrderResponse.OrderItems.Single(x => x.Sku == item.Sku).Quantity;
        });

        pickOrderRequest.Items.RemoveAll(p => p.Quantity == 0);
        await RabbitMQService.Instance.PublishToExchange(_mapper.Map<BaseThirdPartyEvent>(pickOrderRequest));
    }
}