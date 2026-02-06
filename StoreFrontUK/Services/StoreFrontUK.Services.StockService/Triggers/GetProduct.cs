using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using StoreFrontUK.GlobalObjects.Inventory;
using System.ComponentModel;
using System.Net;

namespace ProductService.Functions;

public class GetProduct
{
    private readonly ILogger<GetProduct> _logger;

    public GetProduct(ILogger<GetProduct> logger)
    {
        _logger = logger;
    }

    [Function("GetProduct")]
    public HttpResponseData Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "product/{sku}")] HttpRequestData req,
        string sku)
    {
        _logger.LogInformation("Received request for SKU: {Sku}", sku);

        // Fake product for now
        var product = new ProductDTO
        {
            Sku = sku,
            Description = "Some Product",
            CanReorder = false
        };

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.WriteAsJsonAsync(product);

        return response;
    }
}