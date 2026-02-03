namespace StoreFrontUK.GlobalObjects.Customer;

public record CustomerNameDTO
{
    public string Title { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;
}

public record CustomerDTO
{
    public string CustomerId { get; set; } = string.Empty;

    public CustomerNameDTO CustomerName { get; set; } = new();

    public string CustomerEmailAddress { get; set; } = string.Empty;

    public int LoyaltyPoints { get; set; } = 0;

    public List<CustomerAddressDTO> Addresses { get; set; } = [];

    public List<CustomerContactDTO> CustomerContacts { get; set; } = [];

    public List<CustomerNoteDTO> CustomerNotes { get; set; } = [];
}