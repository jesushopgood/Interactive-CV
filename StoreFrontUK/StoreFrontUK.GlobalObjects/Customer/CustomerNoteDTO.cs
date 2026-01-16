namespace StoreFrontUK.GlobalObjects.Customer;

public record CustomerNoteDTO
{
    public long Id { get; set; }

    public string CustomerId { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;
}