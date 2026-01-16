using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreFrontUK.GlobalObjects.Order;
using StoreFrontUK.Services.OrderService.Commands;
using StoreFrontUK.Services.OrderService.Queries;

namespace StoreFrontUK.Services.OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediatr;

    public OrderController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet("{id}/{productsOnly}")]
    public async Task<IActionResult> Get(long id, bool productsOnly = false)
    {
        return productsOnly ?
                    Ok(await _mediatr.Send(new GetOrderItemsOnOrderQuery { OrderId = id })) :
                    Ok(await _mediatr.Send(new GetOrderQuery { OrderId = id }));
    }

    [HttpGet("exists/{id}")]
    public async Task<IActionResult> GetOrderExists(long id)
    {
        return Ok(await _mediatr.Send(new GetOrderExistsQuery { OrderId = id }));
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _mediatr.Send(new GetAllOrdersQuery()));
    }

    [HttpGet("products/{id}", Name = "Get")]
    public async Task<IActionResult> Get(long id)
    {
        return Ok(await _mediatr.Send(new GetProductsOnOrderQuery { OrderId = id}));
    }

    [HttpPut("{orderId}/{sku}/{quantity}/add-product")]
    public async Task<IActionResult> AddProductToOrder(long orderId, string sku, int quantity)
    {
        await _mediatr.Send(new AddProductToOrderCommand
        {
            OrderId = orderId,
            Sku = sku,
            Quantity = quantity
        });
        
        return await Task.FromResult(Ok($"{orderId}-{sku}"));
    }

    [HttpPut("{orderId}/{customerId}/add-customer")]
    public async Task<IActionResult> AddCustomerToOrder(long orderId, string customerId)
    {
        await _mediatr.Send(new AddCustomerToOrderCommand { OrderId = orderId, CustomerId = customerId });
        return await Task.FromResult(Ok($"{orderId}-{customerId}"));
    }

    [HttpPut("CompleteOrder")]
    public async Task<IActionResult> CompleteOrder(long orderId)
    {
        await _mediatr.Send(new CompletedOrderCommand { OrderId = orderId });
        return await Task.FromResult(Ok($"OrderId: {orderId}"));   
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewOrder(CreateNewOrderDTO createNewOrderDto)
    {
        var createdOrder = await _mediatr.Send(new CreateNewOrderCommand { IsBasketOrder = createNewOrderDto.IsBasketOrder });
        return CreatedAtAction(nameof(Get), new { id = createdOrder.OrderId }, createdOrder);
    }
}
