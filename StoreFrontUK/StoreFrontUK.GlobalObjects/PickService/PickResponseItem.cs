namespace StoreFrontUK.Services.PickService.Models;

public record PickResponseItem : PickOrderItem
{
    public bool CanSatisfy { get; set; }

    public DateTime? EstimatedDeliveryDate { get; set; } = null;

    public decimal? BestPrice { get; set; } = null;
}