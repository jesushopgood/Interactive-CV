namespace StoreFrontUK.Services.CustomerService.Entities;

public record CustomerNote
{
    public long Id { get; set; }

    public Customer Customer { get; set; } = new();

    public string CustomerId { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public DateTime MessageDate { get; set; }
}