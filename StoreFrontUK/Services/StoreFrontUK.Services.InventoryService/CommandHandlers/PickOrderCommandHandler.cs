using MediatR;
using StoreFrontUK.Services.InventoryService.Commands;

using AutoMapper;
using StoreFrontUK.Services.InventoryService.Repostories;
using StoreFrontUK.GlobalObjects.PickService.Responses;

namespace StoreFrontUK.Services.InventoryService.CommandHandlers;

public class InternalPickOrderCommandHandler : IRequestHandler<InternalPickOrderCommand, PickOrderResponse>
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IMapper _mapper;

    public InternalPickOrderCommandHandler(IInventoryRepository inventoryRepository, IMapper mapper)
    {
        _inventoryRepository = inventoryRepository;
        _mapper = mapper;
    }

    public async Task<PickOrderResponse> Handle(InternalPickOrderCommand request, CancellationToken cancellationToken)
    {
        return await _inventoryRepository.PickOrder(request.Items);
    }
}