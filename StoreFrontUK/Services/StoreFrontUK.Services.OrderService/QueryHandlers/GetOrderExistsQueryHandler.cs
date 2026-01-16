using MediatR;
using StoreFrontUK.Services.OrderService.Queries;
using StoreFrontUK.Services.OrderService.Repositories;

namespace StoreFrontUK.Services.OrderService.QueryHandlers;

public class GetOrderExistsQueryHandler : IRequestHandler<GetOrderExistsQuery, bool>
{
    public IOrderRepository _orderRepository;

    public GetOrderExistsQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<bool> Handle(GetOrderExistsQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.Exists(request.OrderId);
    }
}

