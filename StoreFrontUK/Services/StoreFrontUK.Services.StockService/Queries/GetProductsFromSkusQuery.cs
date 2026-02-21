using MediatR;
using StoreFrontUK.GlobalObjects.Inventory;

namespace StoreFrontUK.Services.StockService.Queries;

public record GetProductsFromSkusQuery : IRequest<List<ProductDTO>>
{
    public List<string> ProductSkus { get; set; } = [];
}