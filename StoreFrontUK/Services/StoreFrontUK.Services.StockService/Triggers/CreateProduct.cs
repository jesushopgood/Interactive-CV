using System.Net;
using AutoMapper;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using StoreFrontUK.GlobalObjects.Inventory;
using StoreFrontUK.Services.StockService.Commands;

namespace StoreFrontUK.Services.StockService.Triggers;

public class CreateProduct
{
    private readonly IMediator _mediatr;
    private readonly IMapper _mapper;


    public CreateProduct(IMediator mediatr, IMapper mapper)
    {
        _mapper = mapper;
        _mediatr = mediatr;
    }

    [Function("CreateProduct")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "CreateProduct")] HttpRequestData request)
    {
        var newProductDto = await request.ReadFromJsonAsync<ProductDTO>();
        if (newProductDto is null) throw new ArgumentException("Invalid Product.");

        var result = await _mediatr.Send(new CreateProductCommand { Dto = _mapper.Map<CreateProductDTO>(newProductDto) });
        var response = request.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(result);
        return response;
    }
}