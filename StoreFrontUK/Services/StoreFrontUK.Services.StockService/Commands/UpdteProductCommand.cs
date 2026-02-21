using MediatR;
using StoreFrontUK.GlobalObjects.Inventory;

namespace StoreFrontUK.Services.StockService.Commands;

public record UpdateProductCommand : IRequest
{
    public UpdateProductDTO? Dto { get; set; } = null;
}