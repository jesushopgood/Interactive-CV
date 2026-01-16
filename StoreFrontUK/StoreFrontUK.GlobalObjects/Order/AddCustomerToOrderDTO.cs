namespace StoreFrontUK.GlobalObjects.Order;

public record AddCustomerToOrderDTO
{
    public long OrderId { get; set; } = 0;

    public string CustomerId { get; set; } = string.Empty;
}