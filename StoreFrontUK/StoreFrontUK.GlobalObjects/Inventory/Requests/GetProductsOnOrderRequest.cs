namespace StoreFrontUK.GlobalObjects.Inventory.Requests;

public record GetProductsOnOrderRequest
{
    public List<string> Skus{ get; set; } = [];
}