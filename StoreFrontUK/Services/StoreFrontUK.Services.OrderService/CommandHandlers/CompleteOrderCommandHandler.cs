using AutoMapper;
using MediatR;
using StoreFrontUK.HttpClients;
using StoreFrontUK.Messaging;
using StoreFrontUK.Services.Common.Exceptions;
using StoreFrontUK.Services.OrderService.Entities;
using StoreFrontUK.Services.OrderService.Events;
using StoreFrontUK.Services.OrderService.Repositories;

namespace StoreFrontUK.Services.OrderService.CommandHandlers;

public class CompleteOrderCommandHandler : IRequestHandler<CompletedOrderCommand>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly IMediator _mediatr;
    private readonly CustomerServiceClient _customerServiceClient;

    public CompleteOrderCommandHandler(IMapper mapper,
                                    IOrderRepository orderRepository,
                                    IMediator mediatr,
                                    CustomerServiceClient customerServiceClient)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
        _mediatr = mediatr;
        _customerServiceClient = customerServiceClient;
    }

    public async Task Handle(CompletedOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetById(request.OrderId, o => o.OrderId);
        if (order is null)
            throw new NotFoundException($"Cannot find order {request.OrderId}");

        if (order.CustomerId is null)
            throw new InvalidStateException($"Cannot find customer on order {request.OrderId}");

        if (order.OrderState != OrderState.Open)
            throw new InvalidStateException($"order {request.OrderId} is already closed or awaiting stock.");

        var emailAddress = await _customerServiceClient.GetCustomerEmailAddress(order.CustomerId!);
        var orderCompletedEvent = new OrderCompletedEvent
        {
            OrderId = request.OrderId,
            CustomerId = order.CustomerId ?? string.Empty,
            EmailAddress = emailAddress,            
        };

        await RabbitMQService.Instance.PublishAsync(orderCompletedEvent);
    }
}
