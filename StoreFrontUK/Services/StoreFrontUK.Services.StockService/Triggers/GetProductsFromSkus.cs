using System.Diagnostics.CodeAnalysis;
using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using StoreFrontUK.GlobalObjects.Inventory;
using StoreFrontUK.GlobalObjects.Inventory.Requests;
using StoreFrontUK.Services.StockService.Queries;

namespace StoreFrontUK.Services.StockService.Triggers;

public class GetProductFromSkus
{
    private readonly IMediator _mediatr;
    private readonly IMapper _mapper;


    public GetProductFromSkus(IMediator mediatr, IMapper mapper)
    {
        _mapper = mapper;
        _mediatr = mediatr;
    }

    [Function("GetProductsFromSkus")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "GetProductsFromSkus")] HttpRequestData req)
    {
        GetProductsOnOrderRequest? model = await req.ReadFromJsonAsync<GetProductsOnOrderRequest>();
        if (model is null) throw new ArgumentException("Invalid SKU List");

        var result = await _mediatr.Send(new GetProductsFromSkusQuery { ProductSkus = model.Skus });
        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(result);
        return response;
    }
}