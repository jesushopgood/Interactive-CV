using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreFrontUK.Services.InventoryService.Queries;
using StoreFrontUK.Services.InventoryService.Commands;
using StoreFrontUK.GlobalObjects.Inventory;
using StoreFrontUK.Services.PickService.Requests;
using StoreFrontUK.GlobalObjects.Inventory.Requests;

namespace StoreFrontUK.Services.InventoryService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IMediator _mediatr;

    public InventoryController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet("{sku}", Name = "GetProduct")]
    public async Task<ProductDTO> GetProduct(string sku)
    {
        return await _mediatr.Send(new GetProductQuery { Sku = sku });
    }

    [HttpGet("exists/{sku}")]
    public async Task<IActionResult> GetProductExists(string sku)
    {
        return Ok(await _mediatr.Send(new GetProductExistsQuery { Sku = sku }));
    }

    [HttpGet("can-reorder/{sku}")]
    public async Task<IActionResult> CanReorderProduct(string sku)
    {
        var product = await _mediatr.Send(new GetProductQuery { Sku = sku });
        return await Task.FromResult(Ok(product?.CanReorder));
    }

    [HttpGet()]
    public async Task<IEnumerable<ProductDTO>> GetAllProducts()
    {
        return await _mediatr.Send(new GetAllProductsQuery());
    }

    [HttpPost("OrderProducts")]
    public async Task<IEnumerable<ProductDTO>> GetAllProductsOnOrder(GetProductsOnOrderRequest request)
    {
        return await _mediatr.Send(new GetProductsFromSkusQuery { ProductSkus = request.Skus });
    }

    [HttpPost()]
    public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var createdProduct = await _mediatr.Send(new CreateProductCommand { Dto = createProductDTO });
        Console.WriteLine($"{nameof(GetProduct)}, {createdProduct.Sku}");
        return CreatedAtAction(nameof(GetProduct), new { sku = createdProduct.Sku }, createdProduct);
    }

    [HttpPut()]
    public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        await _mediatr.Send(new UpdateProductCommand { Dto = updateProductDTO });
        return Ok();
    }

    [HttpPut()]
    [Route("PickOrder")]
    public async Task<IActionResult> PickOrder(PickOrderRequest pickOrderRequest)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var response = await _mediatr.Send(new InternalPickOrderCommand { Items = pickOrderRequest.Items });
        return Ok(response);
    }
}