
using StoreFrontUK.GlobalObjects.Order;

namespace StoreFrontUK.HttpClients;

public class OrderServiceClient : BaseServiceClient
{
    public OrderServiceClient(HttpClient httpClient) : base(httpClient) { }

    public async Task<bool> GetOrderExists(long orderId)
    {
        return await GetBoolValueAsync($"exists/{orderId}");
    }

    public async Task<List<OrderItemDTO>> GetProductsOnOrder(long orderId)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync($"{orderId}/true");
        return await DeserializeType<List<OrderItemDTO>>(responseMessage);
    }
}

