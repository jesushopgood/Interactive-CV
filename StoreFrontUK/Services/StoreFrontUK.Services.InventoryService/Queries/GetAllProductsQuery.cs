using MediatR;
using StoreFrontUK.GlobalObjects.Inventory;

namespace StoreFrontUK.Services.InventoryService.Queries;

public record GetAllProductsQuery() : IRequest<List<ProductDTO>> { }