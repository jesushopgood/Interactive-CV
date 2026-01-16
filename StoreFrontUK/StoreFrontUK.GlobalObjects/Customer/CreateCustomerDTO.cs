namespace StoreFrontUK.GlobalObjects.Customer;

public record CreateCustomerDTO
{
    public string CustomerId { get; set; } = string.Empty;
    
    public string CustomerName { get; set; } = string.Empty;

    public string CustomerEmailAddress { get; set; } = string.Empty;
}