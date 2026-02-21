using MediatR;
using StoreFrontUK.GlobalObjects.Inventory;

namespace StoreFrontUK.Services.StockService.Queries;

public record GetAllProductsQuery() : IRequest<List<ProductDTO>> { }