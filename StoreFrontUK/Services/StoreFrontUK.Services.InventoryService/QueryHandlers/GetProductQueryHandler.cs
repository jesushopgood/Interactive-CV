using AutoMapper;
using MediatR;
using StoreFrontUK.GlobalObjects.Inventory;
using StoreFrontUK.Services.InventoryService.Queries;
using StoreFrontUK.Services.InventoryService.Repostories;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDTO?>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<ProductDTO?> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<ProductDTO>(await _productRepository.GetById(request.Sku, p => p.Sku));
        return await Task.FromResult(result);
    }
}