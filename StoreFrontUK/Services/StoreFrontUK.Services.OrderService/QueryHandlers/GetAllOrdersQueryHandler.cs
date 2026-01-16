using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using StoreFrontUK.GlobalObjects.Order;
using StoreFrontUK.Services.OrderService.Repositories;

namespace StoreFrontUK.Services.OrderService.QueryHandlers;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDTO>>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public GetAllOrdersQueryHandler(IMapper mapper, IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }
    public async Task<List<OrderDTO>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var result = await _orderRepository.GetAll([o => o.OrderItems]);
        return await Task.FromResult(_mapper.Map<List<OrderDTO>>(result));
    }
}