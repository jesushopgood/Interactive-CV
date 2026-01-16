using MediatR;

namespace StoreFrontUK.Services.OrderService.Commands;

public record AddProductToOrderCommand : IRequest
{
    public long OrderId { get; set; } = 0;

    public string Sku { get; set; } = string.Empty;

    public int Quantity { get; set; }
}

