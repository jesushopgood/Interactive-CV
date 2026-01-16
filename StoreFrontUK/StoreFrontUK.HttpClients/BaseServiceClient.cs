using System.Text.Json;

namespace StoreFrontUK.HttpClients;

public abstract class BaseServiceClient
{
    protected readonly HttpClient _httpClient;

    protected BaseServiceClient(HttpClient httpClient) : base()
    {
        _httpClient = httpClient;
    }

    protected async Task<bool> GetBoolValueAsync(string url)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            bool result;
            bool.TryParse(json, out result);
            return await Task.FromResult(result);
        }

        return await Task.FromResult(false);
    }

    protected async Task<string> GetStringValueAsync(string url)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(json);
        }

        return await Task.FromResult(string.Empty);
    }

    protected async Task<T> DeserializeType<T>(HttpResponseMessage response) where T : new()
    {
        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var products = JsonSerializer.Deserialize<T>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return await Task.FromResult(products ?? new T());
        }
        return new T();
    }
}