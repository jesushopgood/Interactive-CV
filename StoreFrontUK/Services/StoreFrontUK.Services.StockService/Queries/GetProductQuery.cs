using MediatR;
using StoreFrontUK.GlobalObjects.Inventory;

namespace StoreFrontUK.Services.InventoryService.Queries;

public record GetProductQuery : IRequest<ProductDTO>
{
    public string Sku { get; set; } = string.Empty;
}