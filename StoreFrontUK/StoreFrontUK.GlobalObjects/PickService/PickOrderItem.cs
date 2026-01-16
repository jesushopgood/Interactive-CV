namespace StoreFrontUK.Services.PickService.Models;

public record PickOrderItem
{
    public long Id { get; set; }

    public string Sku { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal? MaxPricePerUnit { get; set; }

    public DateOnly? LatestDelivery { get; set; } 
}