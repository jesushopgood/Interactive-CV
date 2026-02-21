using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using StoreFrontUK.Services.StockService.Queries;
using System.Net;

namespace StoreFrontUK.Services.StockService.Triggers;

public class GetProductExists
{
    private readonly ILogger<GetProductExists> _logger;
    private readonly IMediator _mediatr;
    public GetProductExists(ILogger<GetProductExists> logger, IMediator mediatr)
    {
        _logger = logger;
        _mediatr = mediatr;
    }

    [Function("GetProductExists")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "productexists/{sku}")] HttpRequestData req,
        string sku)
    {
        _logger.LogInformation("Received request for SKU: {Sku}", sku);

        var result = await _mediatr.Send(new GetProductExistsQuery { Sku = sku });

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(result);

        return response;
    }
}