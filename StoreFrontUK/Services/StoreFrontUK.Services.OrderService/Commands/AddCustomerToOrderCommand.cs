using MediatR;

namespace StoreFrontUK.Services.OrderService.Commands;

public record AddCustomerToOrderCommand : IRequest
{
    public long OrderId { get; set; } = 0;

    public string CustomerId { get; set; } = string.Empty;
}