using AutoMapper;
using MediatR;
using StoreFrontUK.GlobalObjects.Inventory;
using StoreFrontUK.Services.StockService.Commands;
using StoreFrontUK.Services.StockService.Entities;
using StoreFrontUK.Services.StockService.Repostories;

namespace StoreFrontUK.Services.StockService.CommandHandlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDTO>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = _mapper.Map<Product>(request.Dto);
        var createdProduct = await _productRepository.Create(newProduct);
        return _mapper.Map<ProductDTO>(createdProduct);
    }
}