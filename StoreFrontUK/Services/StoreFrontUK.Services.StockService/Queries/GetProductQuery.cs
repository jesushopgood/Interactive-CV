using MediatR;
using StoreFrontUK.GlobalObjects.Inventory;

namespace StoreFrontUK.Services.StockService.Queries;

public record GetProductQuery : IRequest<ProductDTO>
{
    public string Sku { get; set; } = string.Empty;
}