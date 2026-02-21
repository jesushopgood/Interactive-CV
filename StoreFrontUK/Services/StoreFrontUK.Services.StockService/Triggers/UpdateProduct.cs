using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using StoreFrontUK.GlobalObjects.Inventory;
using StoreFrontUK.Services.StockService.Commands;

namespace StoreFrontUK.Services.StockService.Triggers;

public class UpdateProduct
{
    private readonly IMediator _mediatr;
    private readonly IMapper _mapper;


    public UpdateProduct(IMediator mediatr, IMapper mapper)
    {
        _mapper = mapper;
        _mediatr = mediatr;
    }

    [Function("UpdateProduct")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "put", Route = "UpdateProduct")] HttpRequestData request)
    {
        var productToUpdate = await request.ReadFromJsonAsync<ProductDTO>();
        if (productToUpdate is null) throw new ArgumentException();

        await _mediatr.Send(new UpdateProductCommand { Dto = _mapper.Map<UpdateProductDTO>(productToUpdate) });
        var response = request.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(productToUpdate);
        return response;
    }
}