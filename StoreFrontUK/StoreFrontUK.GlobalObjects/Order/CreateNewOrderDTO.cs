namespace StoreFrontUK.GlobalObjects.Order;

public record CreateNewOrderDTO
{
    public bool IsBasketOrder { get; set; } = true;
}