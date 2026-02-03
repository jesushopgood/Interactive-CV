using StoreFrontUK.GlobalObjects.Common;

namespace StoreFrontUK.GlobalObjects.Customer;

public record CreateCustomerDTO
{
    public string CustomerId { get; set; } = string.Empty;

    public CustomerNameDTO CustomerName { get; set; } = new();

    public string CustomerEmailAddress { get; set; } = string.Empty;
}