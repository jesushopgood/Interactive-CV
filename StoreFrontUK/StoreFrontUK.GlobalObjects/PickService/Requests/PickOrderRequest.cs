using StoreFrontUK.GlobalObjects.PickService.Enums;
using StoreFrontUK.Services.PickService.Models;

namespace StoreFrontUK.Services.PickService.Requests;

public class PickOrderRequest
{
    public bool ForceInternal { get; set; }

    public PickResponsePreference PickResponsePreference { get; set; }

    public DateTime Deadline { get; set; }

    public List<PickOrderItem> Items { get; set; } = [];
}