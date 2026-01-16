
using StoreFrontUK.GlobalObjects.PickService.Enums;
using StoreFrontUK.Services.PickService.Models;

namespace StoreFrontUK.GlobalObjects.PickService.Responses;

public record PickOrderResponse
{
    public StockPickResult PickResult { get; set; }

    public List<PickOrderItem> OrderItems { get; set; } = [];
}