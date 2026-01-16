public record SendProductOutOfStockEmailRequest
{
    public string Sku { get; set; } = string.Empty;
}