using MediatR;
using StoreFrontUK.Services.OrderService.Commands;

public record CompletedOrderCommand : IRequest
{
    public long OrderId { get; set; }
}