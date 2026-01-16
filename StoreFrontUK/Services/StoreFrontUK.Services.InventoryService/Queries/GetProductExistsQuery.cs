using MediatR;

namespace StoreFrontUK.Services.InventoryService.Queries;

public record GetProductExistsQuery : IRequest<bool>
{
    public string Sku { get; set; } = string.Empty;
}