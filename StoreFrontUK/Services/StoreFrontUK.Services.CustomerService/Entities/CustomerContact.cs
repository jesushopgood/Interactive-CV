using System.ComponentModel.DataAnnotations;
using StoreFrontUK.GlobalObjects.Customer.Enums;

namespace StoreFrontUK.Services.CustomerService.Entities;

public record CustomerContact
{
    [Key]
    public long Id { get; set; }

    public Customer Customer { get; set; } = new();

    public string CustomerId { get; set; } = string.Empty;

    public CustomerContactType CustomerContactType { get; set; }

    public string Value { get; set; } = string.Empty;
}