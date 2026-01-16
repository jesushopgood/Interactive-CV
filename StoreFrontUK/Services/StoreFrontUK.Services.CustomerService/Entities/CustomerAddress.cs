using System.ComponentModel.DataAnnotations;
using StoreFrontUK.GlobalObjects.Customer.Enums;

namespace StoreFrontUK.Services.CustomerService.Entities;


public record CustomerAddress
{
    [Key]
    public long Id { get; set; }

    public string CustomerId { get; set; } = string.Empty;

    public Customer Customer { get; set; } = new ();

    [Required]
    public string Line1 { get; set; } = string.Empty;

    public string Line2 { get; set; } = string.Empty;

    [Required]
    public string Postcode { get; set; } = string.Empty;
    
    public AddressType AddressType { get; set; }
}