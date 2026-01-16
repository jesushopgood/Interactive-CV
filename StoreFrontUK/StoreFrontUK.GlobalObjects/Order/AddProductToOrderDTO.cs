namespace StoreFrontUK.GlobalObjects.Order;

public record AddProductToOrderDTO
{
    public long OrderId { get; set; } = 0;

    public string ProductId { get; set; } = string.Empty;
}