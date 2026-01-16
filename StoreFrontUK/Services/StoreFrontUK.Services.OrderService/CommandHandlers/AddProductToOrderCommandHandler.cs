using System.Transactions;
using AutoMapper;
using MediatR;
using StoreFrontUK.HttpClients;
using StoreFrontUK.Messaging;
using StoreFrontUK.Messaging.Events;
using StoreFrontUK.Services.Common.Exceptions;
using StoreFrontUK.Services.OrderService.Commands;
using StoreFrontUK.Services.OrderService.Repositories;

namespace StoreFrontUK.Services.OrderService.CommandHandlers;

public class AddProductToOrderCommandHandler : IRequestHandler<AddProductToOrderCommand>
{
    private IMapper _mapper;

    private readonly IOrderRepository _orderRepository;
    private readonly IOrderProductRepository _orderProductRepository;
    private readonly InventoryServiceClient _inventoryServiceClient;
    private readonly IMediator _mediatr;
    public AddProductToOrderCommandHandler(IMapper mapper,
                                            IOrderRepository orderRepository,
                                            IOrderProductRepository orderProductRepository,
                                            InventoryServiceClient inventoryServiceClient,
                                            IMediator mediatr)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
        _orderProductRepository = orderProductRepository;
        _inventoryServiceClient = inventoryServiceClient;
        _mediatr = mediatr;
    }

    public async Task Handle(AddProductToOrderCommand request, CancellationToken cancellationToken)
    {
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            var order = await _orderRepository.GetById(request.OrderId, o => o.OrderId, [o => o.OrderItems]);
            if (order is null)
                throw new NotFoundException($"Cannot find order {request.OrderId}");

            if (!await _inventoryServiceClient.GetProductExists(request.Sku))
                throw new NotFoundException($"Cannot find product {request.Sku}");

            var productAddedEvent = new ProductAddedEvent { RequestedSku = request.Sku, RequestedQuantity = request.Quantity };
            await RabbitMQService.Instance.PublishAsync(productAddedEvent);

            var orderItem = order.OrderItems.FirstOrDefault(oi => oi.Sku == request.Sku);
            if (orderItem is null)
                order.OrderItems.Add(new OrderItem { Sku = request.Sku, Quantity = request.Quantity });
            else
                orderItem.Quantity += request.Quantity;

            await _orderProductRepository.AddOrderProduct(order, request.Sku);
            await _orderRepository.SaveChangesAsync();
            scope.Complete();
        }
    }
}
