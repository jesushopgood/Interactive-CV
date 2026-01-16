namespace StoreFrontUK.GlobalObjects.Customer;

public record CustomerDTO
{
    public string CustomerId { get; set; } = string.Empty;

    public string CustomerName { get; set; } = string.Empty;

    public string CustomerEmailAddress { get; set; } = string.Empty;

    public int LoyaltyPoints { get; set; } = 0;

    public List<CustomerAddressDTO> Addresses { get; set; } = [];

    public List<CustomerContactDTO> CustomerContacts { get; set; } = [];

    public List<CustomerNoteDTO> CustomerNotes { get; set; } = [];
}