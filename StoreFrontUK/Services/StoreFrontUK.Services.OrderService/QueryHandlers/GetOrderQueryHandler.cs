using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreFrontUK.GlobalObjects.Order;
using StoreFrontUK.Services.Common.Exceptions;
using StoreFrontUK.Services.OrderService.Data;
using StoreFrontUK.Services.OrderService.Entities;
using StoreFrontUK.Services.OrderService.Queries;
using StoreFrontUK.Services.OrderService.Repositories;

namespace StoreFrontUK.Services.OrderService.QueryHandlers;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDTO>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public GetOrderQueryHandler(IMapper mapper, IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public async Task<OrderDTO> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var requestedOrder = await _orderRepository.GetById(request.OrderId, o => o.OrderId, [o => o.OrderItems]);
        if (requestedOrder is null)
            throw new NotFoundException($"Cannot find order {request.OrderId}");

        var mappedOrder = _mapper.Map<OrderDTO>(requestedOrder);
        return await Task.FromResult(mappedOrder);
    }
}