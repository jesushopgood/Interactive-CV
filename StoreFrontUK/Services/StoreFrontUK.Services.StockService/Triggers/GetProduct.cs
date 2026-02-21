using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using StoreFrontUK.Services.StockService.Queries;
using System.Net;

namespace StoreFrontUK.Services.StockService.Functions;

public class GetProduct
{
    private readonly ILogger<GetProduct> _logger;
    private readonly IMediator _mediatr;
    public GetProduct(ILogger<GetProduct> logger, IMediator mediatr)
    {
        _logger = logger;
        _mediatr = mediatr;
    }

    [Function("GetProduct")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "product/{sku}")] HttpRequestData req,
        string sku)
    {
        _logger.LogInformation("Received request for SKU: {Sku}", sku);

        var result = await _mediatr.Send(new GetProductQuery { Sku = sku });
        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(result);

        return response;
    }
}