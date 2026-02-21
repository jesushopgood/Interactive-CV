using AutoMapper;
using MediatR;
using StoreFrontUK.Services.StockService.Commands;
using StoreFrontUK.Services.StockService.Entities;
using StoreFrontUK.Services.StockService.Repostories;

namespace StoreFrontUK.Services.StockService.CommandHandlers;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        await _productRepository.Update(_mapper.Map<Product>(request.Dto));
    }
}