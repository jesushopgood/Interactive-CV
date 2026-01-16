using StoreFrontUK.GlobalObjects.Customer;

namespace StoreFrontUK.HttpClients;

public class CustomerServiceClient : BaseServiceClient
{
    public CustomerServiceClient(HttpClient httpClient) : base(httpClient) { }

    public async Task<bool> GetCustomerExists(string customerId)
    {
        return await GetBoolValueAsync($"exists/{customerId}");
    }

    public async Task<string> GetCustomerEmailAddress(string customerId)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(customerId);
        var customer = await DeserializeType<CustomerDTO>(response);
        return customer.CustomerEmailAddress;
    }
}