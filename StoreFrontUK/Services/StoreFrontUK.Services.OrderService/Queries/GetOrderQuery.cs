using MediatR;
using StoreFrontUK.GlobalObjects.Order;

namespace StoreFrontUK.Services.OrderService.Queries;

public record GetOrderQuery : IRequest<OrderDTO>
{
    public long OrderId { get; set; }        
}