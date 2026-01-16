using MediatR;
using StoreFrontUK.GlobalObjects.Inventory;

namespace StoreFrontUK.Services.InventoryService.Queries;

public record GetProductsOnOrderQuery : IRequest<List<ProductDTO>>
{
    public long OrderId { get; set; }
}