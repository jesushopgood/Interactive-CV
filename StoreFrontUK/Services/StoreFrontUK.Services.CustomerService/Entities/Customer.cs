using System.ComponentModel.DataAnnotations;
using StoreFrontUK.GlobalObjects.Common;
using StoreFrontUK.Services.Common.Repository;

namespace StoreFrontUK.Services.CustomerService.Entities;

public record Customer : IEntityWithKey<string>
{
    [Key]
    public string CustomerId { get; set; } = string.Empty;

    public string CustomerTitle { get; set; } = string.Empty;

    public string CustomerFirstName { get; set; } = string.Empty;

    public string CustomerSurname { get; set; } = string.Empty;

    public string CustomerEmailAddress { get; set; } = string.Empty;

    public int LoyaltyPoints { get; set; } = 0;

    public List<CustomerAddress> Addresses { get; set; } = [];

    public List<CustomerContact> CustomerContacts { get; set; } = [];

    public List<CustomerNote> CustomerNotes { get; set; } = [];

    public string GetKey() => CustomerId;
}