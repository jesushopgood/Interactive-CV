using System.Net.Http.Json;
using StoreFrontUK.Services.PickService.Requests;
using StoreFrontUK.Services.PickService.Models;
using StoreFrontUK.GlobalObjects.PickService.Responses;
using StoreFrontUK.GlobalObjects.Inventory.Requests;
using StoreFrontUK.GlobalObjects.Inventory;

namespace StoreFrontUK.HttpClients;

public class InventoryServiceClient : BaseServiceClient
{
    public InventoryServiceClient(HttpClient httpClient) : base(httpClient) { }

    public async Task<bool> GetProductExists(string productId)
    {
        return await GetBoolValueAsync($"exists/{productId}");
    }

    public async Task<bool> CanReorderProduct(string productId)
    {
        return await GetBoolValueAsync($"can-reorder/{productId}");
    }

    public async Task<List<ProductDTO>> GetProductsOnOrder(List<string> skus)
    {
        var request = new GetProductsOnOrderRequest { Skus = skus };
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"OrderProducts", request);
        return await DeserializeType<List<ProductDTO>>(response);
    }

    public async Task<PickOrderResponse> PickProducts(List<PickOrderItem> items)
    {
        var request = new PickOrderRequest { Items = items };
        HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"PickOrder", request);
        return await DeserializeType<PickOrderResponse>(response);
    }
}