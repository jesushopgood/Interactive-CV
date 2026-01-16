using MediatR;
using StoreFrontUK.GlobalObjects.Order;

namespace StoreFrontUK.Services.OrderService.Commands;

public record CreateNewOrderCommand : IRequest<OrderDTO>
{
    public bool IsBasketOrder { get; set; } = true;
}