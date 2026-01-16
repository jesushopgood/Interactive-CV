using MediatR;
using StoreFrontUK.GlobalObjects.Inventory;

namespace StoreFrontUK.Services.InventoryService.Commands;

public record UpdateProductCommand : IRequest
{
    public UpdateProductDTO? Dto { get; set; } = null;
}