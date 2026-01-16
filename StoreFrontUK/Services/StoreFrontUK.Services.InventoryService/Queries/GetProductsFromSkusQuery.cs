using MediatR;
using StoreFrontUK.GlobalObjects.Inventory;

namespace StoreFrontUK.Services.InventoryService.Queries;

public record GetProductsFromSkusQuery : IRequest<List<ProductDTO>>
{
    public List<string> ProductSkus { get; set; } = [];
}