namespace StoreFrontUK.GlobalObjects.Order;

public record OrderDTO
{
    public long OrderId { get; set; } = 0;

    public string? CustomerId { get; set; } = null;

    public List<OrderItemDTO> OrderItems { get; set; } = [];

    public bool OrderCompleted { get; set; }
}