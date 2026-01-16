using MediatR;
using StoreFrontUK.GlobalObjects.PickService.Responses;
using StoreFrontUK.Services.PickService.Models;

namespace StoreFrontUK.Services.InventoryService.Commands;

public record InternalPickOrderCommand : IRequest<PickOrderResponse>
{
    public List<PickOrderItem> Items { get; set; } = [];
}