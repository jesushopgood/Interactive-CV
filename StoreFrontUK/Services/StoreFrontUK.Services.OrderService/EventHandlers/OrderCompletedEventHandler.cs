using AutoMapper;
using StoreFrontUK.GlobalObjects.PickService.Enums;
using StoreFrontUK.GlobalObjects.PickService.Responses;
using StoreFrontUK.HttpClients;
using StoreFrontUK.Messaging;
using StoreFrontUK.Messaging.Interfaces;
using StoreFrontUK.Services.OrderService.Data;
using StoreFrontUK.Services.OrderService.Entities;
using StoreFrontUK.Services.OrderService.Events;
using StoreFrontUK.Services.PickService;
using StoreFrontUK.Services.PickService.Models;
using StoreFrontUK.Services.PickService.Requests;

namespace StoreFrontUK.Services.OrderService.EventHandlers;

public class OrderCompletedEventHandler : IAsyncEventProcessor<OrderCompletedEvent>
{
    private readonly EmailServiceClient _emailServiceClient;
    private readonly CustomerServiceClient _customerServiceClient;
    private readonly OrderServiceClient _orderServiceClient;
    private readonly IMapper _mapper;
    private readonly IPickService _pickService;
    private readonly OrderDbContext _orderDbContext;

    public OrderCompletedEventHandler(
        EmailServiceClient emailServiceClient,
        CustomerServiceClient customerServiceClient,
        OrderServiceClient orderServiceClient,
        IMapper mapper,
        IPickService pickService,
        OrderDbContext orderDbContext)
    {
        _emailServiceClient = emailServiceClient;
        _customerServiceClient = customerServiceClient;
        _orderServiceClient = orderServiceClient;
        _mapper = mapper;
        _pickService = pickService;
        _orderDbContext = orderDbContext;
    }

    public async Task Execute(OrderCompletedEvent orderCompletedEvent)
    {
        PickOrderRequest? internalRequest = null;
        PickOrderResponse? pickOrderResponse = null;

        var order = _orderDbContext.Orders.Single(o => o.OrderId == orderCompletedEvent.OrderId);

        if (await _customerServiceClient.GetCustomerExists(orderCompletedEvent.CustomerId))
        {
            var productsToPick = await _orderServiceClient.GetProductsOnOrder(orderCompletedEvent.OrderId);
            if (productsToPick.Any())
            {
                internalRequest = new PickOrderRequest
                {
                    ForceInternal = false,
                    PickResponsePreference = PickResponsePreference.Price,
                    Deadline = DateTime.Now.AddSeconds(30),
                    Items = _mapper.Map<List<PickOrderItem>>(productsToPick)
                };

                pickOrderResponse = await _pickService.PickAsync(internalRequest);
            }

            if (pickOrderResponse?.PickResult == StockPickResult.SatisfiedInternally)
            {
                await _emailServiceClient.SendOrderCompleteEmail(orderCompletedEvent.OrderId, orderCompletedEvent.EmailAddress);
                await RabbitMQService.Instance.AcceptMessage(orderCompletedEvent.DeliveryTag);
                order.OrderState = OrderState.Completed;
            }
            else
            {
                order.OrderState = OrderState.AwaitingStock;
                order.ExternalRequestDeadline = DateTime.Now;
                await _pickService.PickExternalAsync(internalRequest!, pickOrderResponse!);
                await _emailServiceClient.SendAwaitingStockEmail(orderCompletedEvent.OrderId, orderCompletedEvent.EmailAddress);
                await RabbitMQService.Instance.AcceptMessage(orderCompletedEvent.DeliveryTag);
            }
        }
        else
        {
            await RabbitMQService.Instance.RejectMessage(orderCompletedEvent.DeliveryTag);
            order.OrderState = OrderState.Failed;
        }

        await _orderDbContext.SaveChangesAsync();
    }
}