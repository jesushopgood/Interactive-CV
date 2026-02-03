using System.ComponentModel.DataAnnotations;
using StoreFrontUK.GlobalObjects.Common;
using StoreFrontUK.Services.Common.Repository;

namespace StoreFrontUK.Services.CustomerService.Entities;

public record CustomerName
{
    public string Title { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;
}

public record Customer : IEntityWithKey<string>
{
    [Key]
    public string CustomerId { get; set; } = string.Empty;

    public CustomerName CustomerName { get; set; } = new();

    public string CustomerEmailAddress { get; set; } = string.Empty;

    public int LoyaltyPoints { get; set; } = 0;

    public List<CustomerAddress> Addresses { get; set; } = [];

    public List<CustomerContact> CustomerContacts { get; set; } = [];

    public List<CustomerNote> CustomerNotes { get; set; } = [];

    public string GetKey()
    {
        if (string.IsNullOrEmpty(CustomerId))
        {
            CustomerId = Guid.NewGuid().ToString();
            return CustomerId;
        }
        else return CustomerId;
    }
}