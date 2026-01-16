using System.Text;
using System.Text.Json;

namespace StoreFrontUK.HttpClients;

public class EmailServiceClient : BaseServiceClient
{
    public EmailServiceClient(HttpClient httpClient) : base(httpClient) { }

    private async Task PostPayload(string json, string path)
    {
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        await _httpClient.PostAsync(path, content);
        await Task.CompletedTask;
    }

    public async Task SendOrderCompleteEmail(long orderId, string emailAddress)
    {
        var payload = new { OrderId = orderId, Recipient = emailAddress };
        await PostPayload(JsonSerializer.Serialize(payload), "completed");
    }

    public async Task SendAwaitingStockEmail(long orderId, string emailAddress)
    {
        var payload = new { OrderId = orderId, Recipient = emailAddress };
        await PostPayload(JsonSerializer.Serialize(payload), "awaiting-stock");
    }

    public async Task SendProductOutOfStockEmail(string productSku)
    {
        var payload = new { Sku = productSku };
        await PostPayload(JsonSerializer.Serialize(payload), "out-of-stock");
    }
}