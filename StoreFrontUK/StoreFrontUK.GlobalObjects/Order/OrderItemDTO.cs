namespace StoreFrontUK.GlobalObjects.Order;

public record OrderItemDTO
{
    public long OrderItemId { get; set; }

    public long OrderId { get; set; }

    public string Sku { get; set; } = string.Empty;

    public int Quantity { get; set; }
}