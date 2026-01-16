using MediatR;
using StoreFrontUK.GlobalObjects.Inventory;

namespace StoreFrontUK.Services.OrderService.Queries;

public record GetProductsOnOrderQuery() : IRequest<List<ProductDTO>>
{
    public long OrderId { get; set; }
}
