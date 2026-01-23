using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreFrontUK.Services.CustomerService.Commands;
using StoreFrontUK.Services.CustomerService.Queries;
using StoreFrontUK.GlobalObjects.Customer;

namespace StoreFrontUK.Services.CustomerService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediatr;

    public CustomerController(IMediator mediatr, ILogger<CustomerController> logger)
    {
        _mediatr = mediatr;
    }

    [HttpGet("ping")]
    public IActionResult Get() => Ok("pong");

    [HttpGet()]
    public async Task<IActionResult> GetAllCustomers()
    {
        return Ok(await _mediatr.Send(new GetAllCustomersQuery()));
    }

    [HttpGet("{id}", Name = "GetCustomer")]
    public async Task<IActionResult> GetCustomer(string id)
    {
        var result = await _mediatr.Send(new GetCustomerQuery { CustomerId = id });
        return result != null ? Ok(result) : NotFound();
    }

    [HttpGet("exists/{id}")]
    public async Task<IActionResult> GetCustomerExists(string id)
    {
        return Ok(await _mediatr.Send(new GetCustomerExistsQuery { CustomerId = id }));
    }

    [HttpPost()]
    public async Task<IActionResult> CreateCustomer(CreateCustomerDTO createCustomerDTO)
    {
        var createdEntity = await _mediatr.Send(new CreateCustomerCommand { Dto = createCustomerDTO });
        return CreatedAtAction(nameof(GetCustomer), new { id = createdEntity.CustomerId }, createdEntity);
    }

    [HttpPost("filters")]
    public async Task<IActionResult> GetCustomersWithFilters(GetCustomersWithFiltersDTO getCustomersWithFiltersDTO)
    {
        var result = await _mediatr.Send(new GetCustomersWithParamsQuery
        {
            Dto = getCustomersWithFiltersDTO
        });

        return Ok(result);
    }

    [HttpPut()]
    public async Task<IActionResult> UpdateCustomer(UpdateCustomerDTO updateCustomerDTO)
    {
        return await Task.FromResult(Ok(_mediatr.Send(new UpdateCustomerCommand { Dto = updateCustomerDTO })));
    }
}