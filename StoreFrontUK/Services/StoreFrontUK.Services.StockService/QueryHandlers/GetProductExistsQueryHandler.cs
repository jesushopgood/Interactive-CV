using AutoMapper;
using MediatR;
using StoreFrontUK.GlobalObjects.Inventory;
using StoreFrontUK.Services.StockService.Queries;
using StoreFrontUK.Services.StockService.Repostories;

namespace StoreFrontUK.Services.StockService.QueryHandlers;

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