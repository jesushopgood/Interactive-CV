using AutoMapper;
using MediatR;
using StoreFrontUK.GlobalObjects.Order;
using StoreFrontUK.Services.OrderService.Commands;
using StoreFrontUK.Services.OrderService.Entities;
using StoreFrontUK.Services.OrderService.Repositories;

namespace StoreFrontUK.Services.OrderService.CommandHandlers;

public class CreateNewOrderCommandHandler : IRequestHandler<CreateNewOrderCommand, OrderDTO>
{
    
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public CreateNewOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public async Task<OrderDTO> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
    {
        var newOrder = new Order();
        var createdEntity = await _orderRepository.Create(newOrder);
        return _mapper.Map<OrderDTO>(createdEntity);
    }
}