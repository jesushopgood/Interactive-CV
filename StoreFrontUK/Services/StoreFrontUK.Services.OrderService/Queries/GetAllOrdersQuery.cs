using MediatR;
using StoreFrontUK.GlobalObjects.Order;

public record GetAllOrdersQuery : IRequest<List<OrderDTO>>
{
    public bool IncludeBasketOrder { get; set; } = false;
}