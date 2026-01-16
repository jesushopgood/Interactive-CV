using System.ComponentModel.DataAnnotations;
using StoreFrontUK.GlobalObjects.PickService.Enums;
using StoreFrontUK.Services.PickService.Models;

namespace StoreFrontUK.Messaging.Events;

public class BaseThirdPartyEvent : BaseEvent
{
    [Key]
    public long OrderId { get; set; }
    
    public PickResponsePreference PickResponsePreference { get; set; }

    public List<PickOrderItem> Items { get; set; } = [];

    public DateTime Deadline { get; set; }
}