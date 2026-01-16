using System.ComponentModel.DataAnnotations;
using StoreFrontUK.GlobalObjects.Customer.Enums;

namespace StoreFrontUK.GlobalObjects.Customer;

public record CustomerContactDTO
{
    [Key]
    public long Id { get; set; }

    public string CustomerId { get; set; } = string.Empty;

    public CustomerContactType CustomerContactType { get; set; }

    public string Value { get; set; } = string.Empty;
}