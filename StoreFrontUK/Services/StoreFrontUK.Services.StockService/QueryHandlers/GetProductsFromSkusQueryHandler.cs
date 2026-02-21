using AutoMapper;
using MediatR;
using StoreFrontUK.GlobalObjects.Inventory;
using StoreFrontUK.Services.StockService.Queries;
using StoreFrontUK.Services.StockService.Repostories;
namespace StoreFrontUK.Services.StockService.QueryHandlers;

public class GetProductsFromSkusQueryHandler : IRequestHandler<GetProductsFromSkusQuery, List<ProductDTO>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetProductsFromSkusQueryHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<List<ProductDTO>> Handle(GetProductsFromSkusQuery request, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetProductsFromSkus(request.ProductSkus);
        return _mapper.Map<List<ProductDTO>>(result);
    }
}

