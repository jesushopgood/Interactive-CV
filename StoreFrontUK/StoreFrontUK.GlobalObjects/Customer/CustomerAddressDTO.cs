using StoreFrontUK.GlobalObjects.Customer.Enums;

namespace StoreFrontUK.GlobalObjects.Customer;

public record CustomerAddressDTO
{
    public long Id { get; set; }

    public string Line1 { get; set; } = string.Empty;

    public string Line2 { get; set; } = string.Empty;

    public string Postcode { get; set; } = string.Empty;

    public AddressType AddressType { get; set; }
}