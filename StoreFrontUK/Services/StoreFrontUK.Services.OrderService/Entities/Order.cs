using System.ComponentModel.DataAnnotations;
using StoreFrontUK.Services.Common.Repository;

namespace StoreFrontUK.Services.OrderService.Entities;

public enum OrderState
{
    Open,
    AwaitingStock,
    Completed,
    Failed
}

public record Order : IHasKey<long>
{
    [Key]
    public long OrderId { get; set; } = 0;

    public string? CustomerId { get; set; }

    public List<OrderItem> OrderItems { get; set; } = [];

    public OrderState OrderState { get; set; }

    public DateTime? ExternalRequestDeadline { get; set; } = null;

    //public List<SupplierResponseEvent> SupplierResponseEvents { get; set; } = [];

    public long GetKey() => OrderId;
}