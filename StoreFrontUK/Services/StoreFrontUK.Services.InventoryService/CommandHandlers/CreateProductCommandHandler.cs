using AutoMapper;
using MediatR;
using StoreFrontUK.Services.InventoryService.Entities;
using StoreFrontUK.Services.InventoryService.Commands;
using StoreFrontUK.Services.InventoryService.Repostories;
using StoreFrontUK.GlobalObjects.Inventory;

namespace StoreFrontUK.Services.InventoryService.CommandHandlers;

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
        var newProduct = _mapper.Map<Product>(request.Dto!);
        var createdProduct = await _productRepository.Create(newProduct);
        return _mapper.Map<ProductDTO>(createdProduct);
    }
}