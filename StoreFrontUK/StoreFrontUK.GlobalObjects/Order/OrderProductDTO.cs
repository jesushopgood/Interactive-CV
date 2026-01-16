namespace StoreFrontUK.GlobalObjects.Order;

public record OrderProductDTO
{
    public long OrderId { get; set; }

    public string Sku { get; set; } = string.Empty;
}