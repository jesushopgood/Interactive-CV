using MediatR;

namespace StoreFrontUK.Services.StockService.Queries;

public record GetProductExistsQuery : IRequest<bool>
{
    public string Sku { get; set; } = string.Empty;
}