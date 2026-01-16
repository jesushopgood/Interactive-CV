using MediatR;
using StoreFrontUK.GlobalObjects.Order;

namespace StoreFrontUK.Services.OrderService.Queries;

public record GetOrderItemsOnOrderQuery : IRequest<List<OrderItemDTO>>
{
    public long OrderId { get; set; } = 0;
}    