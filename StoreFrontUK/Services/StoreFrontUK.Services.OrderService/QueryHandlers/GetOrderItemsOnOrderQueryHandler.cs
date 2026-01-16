using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using StoreFrontUK.GlobalObjects.Order;
using StoreFrontUK.Services.Common.Exceptions;
using StoreFrontUK.Services.OrderService.Queries;
using StoreFrontUK.Services.OrderService.Repositories;

namespace StoreFrontUK.Services.OrderService.QueryHandlers;

public class GetOrderItemsOnOrderQueryHandler : IRequestHandler<GetOrderItemsOnOrderQuery, List<OrderItemDTO>>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public GetOrderItemsOnOrderQueryHandler(IMapper mapper, IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }
    public async Task<List<OrderItemDTO>> Handle(GetOrderItemsOnOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetById(request.OrderId, o => o.OrderId, [o => o.OrderItems]);
        if (order is null)
            throw new NotFoundException($"Order Not Found {request.OrderId}");

        var orderItemsDTO = order.OrderItems.AsQueryable().ProjectTo<OrderItemDTO>(_mapper.ConfigurationProvider);
        return await Task.FromResult(orderItemsDTO.ToList());
    }
}