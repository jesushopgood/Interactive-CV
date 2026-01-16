using AutoMapper;
using MediatR;
using StoreFrontUK.HttpClients;
using StoreFrontUK.Services.Common.Exceptions;
using StoreFrontUK.Services.OrderService.Commands;
using StoreFrontUK.Services.OrderService.Data;
using StoreFrontUK.Services.OrderService.Repositories;

namespace StoreFrontUK.Services.OrderService.CommandHandlers;

public class AddCustomerToOrderCommandHandler : IRequestHandler<AddCustomerToOrderCommand>
{
    private IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly CustomerServiceClient _customerServiceClient;

    public AddCustomerToOrderCommandHandler(IMapper mapper,
                                            IOrderRepository orderRepository,
                                            CustomerServiceClient customerServiceClient)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
        _customerServiceClient = customerServiceClient;
    }

    public async Task Handle(AddCustomerToOrderCommand request, CancellationToken cancellationToken)
    {
        if (!await _customerServiceClient.GetCustomerExists(request.CustomerId))
            throw new NotFoundException($"Cannot find customer { request.CustomerId }");

        await _orderRepository.AddCustomerToOrder(request.OrderId, request.CustomerId);
    }
}