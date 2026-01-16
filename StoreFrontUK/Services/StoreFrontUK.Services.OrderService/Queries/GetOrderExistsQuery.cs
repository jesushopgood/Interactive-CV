using MediatR;

namespace StoreFrontUK.Services.OrderService.Queries;

public record GetOrderExistsQuery : IRequest<bool>
{
    public long OrderId { get; set; }
}