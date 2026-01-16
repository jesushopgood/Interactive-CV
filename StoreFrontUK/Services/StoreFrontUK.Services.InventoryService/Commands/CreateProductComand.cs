using MediatR;
using StoreFrontUK.GlobalObjects.Inventory;

namespace StoreFrontUK.Services.InventoryService.Commands;

public record CreateProductCommand : IRequest<ProductDTO>
{
    public CreateProductDTO? Dto { get; set; } = null;
}