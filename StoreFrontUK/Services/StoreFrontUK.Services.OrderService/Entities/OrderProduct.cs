using StoreFrontUK.Services.Common.Repository;

namespace StoreFrontUK.Services.OrderService.Entities;

public record OrderProduct : IHasKey<long>
{
    public long OrderProductId { get; set; }
    public Order Order { get; set; } = new();
    public long OrderId { get; set; }
    public string Sku { get; set; } = string.Empty;

    public long GetKey() => OrderProductId;
}