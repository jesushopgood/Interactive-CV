using System.Net;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using StoreFrontUK.Services.StockService.Queries;

namespace StoreFrontUK.Services.StockService.Functions;

public class GetAllProducts
{
    private readonly ILogger<GetProduct> _logger;
    private readonly IMediator _mediatr;
    public GetAllProducts(ILogger<GetProduct> logger, IMediator mediatr)
    {
        _logger = logger;
        _mediatr = mediatr;
    }

    [Function("GetAllProducts")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "products")] HttpRequestData req,
                                            string sku)
    {
        _logger.LogInformation("Received request for all products");

        var result = await _mediatr.Send(new GetAllProductsQuery());
        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(result);

        return response;
    }
}