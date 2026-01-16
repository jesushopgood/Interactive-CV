using MediatR;
using StoreFrontUK.Services.InventoryService.Data;
using StoreFrontUK.Services.InventoryService.Queries;
using StoreFrontUK.Services.InventoryService.Repostories;

namespace StoreFrontUK.Services.OrderService.QueryHandlers;

public class GetProductExistsQueryHandler : IRequestHandler<GetProductExistsQuery, bool>
{
    private readonly IProductRepository _productRepository;

    public GetProductExistsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<bool> Handle(GetProductExistsQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.Exists(request.Sku);
    }
}