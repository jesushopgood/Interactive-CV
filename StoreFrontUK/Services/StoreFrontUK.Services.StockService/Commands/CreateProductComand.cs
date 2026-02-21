using MediatR;
using StoreFrontUK.GlobalObjects.Inventory;

namespace StoreFrontUK.Services.StockService.Commands;

public record CreateProductCommand : IRequest<ProductDTO>
{
    public CreateProductDTO? Dto { get; set; } = null;
}