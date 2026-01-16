using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using StoreFrontUK.Services.InventoryService.Queries;
using StoreFrontUK.Services.InventoryService.Data;
using StoreFrontUK.GlobalObjects.Inventory;
using StoreFrontUK.Services.InventoryService.Repostories;

namespace StoreFrontUK.Services.InventoryService.QueryHandlers;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDTO>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<ProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetAll();
        return await Task.FromResult(_mapper.Map<List<ProductDTO>>(result));
    }
}