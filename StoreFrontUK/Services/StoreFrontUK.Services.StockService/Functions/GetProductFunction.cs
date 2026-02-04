using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using StoreFrontUK.Services.InventoryService.Queries;

namespace StoreFrontUk.Services.StockService.Functions;

public class GetProductFunction
{
    private readonly IMediator _mediatr;

    private readonly ILogger<GetProductFunction> _logger;

    public GetProductFunction(ILogger<GetProductFunction> logger, IMediator mediatr)
    {
        _logger = logger;
        _mediatr = mediatr;
    }

    [Function("GetProductFunction")]
    public async Task<IResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "products/{sku}")]
                                            HttpRequest req,
                                            string sku)
    {
        var result = await _mediatr.Send(new GetProductQuery { Sku = sku });
        return Results.Ok(result);
    }
}
