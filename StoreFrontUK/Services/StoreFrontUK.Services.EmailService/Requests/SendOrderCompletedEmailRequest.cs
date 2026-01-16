namespace StoreFrontUK.Services.EmailService.Requests;

public record SendOrderCompletedEmailRequest
{
    public long OrderId { get; set; }
    public string Recipient { get; set; } = string.Empty;
}