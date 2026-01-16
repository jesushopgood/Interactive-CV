using Microsoft.AspNetCore.Mvc;
using StoreFrontUK.Services.EmailService.Requests;

namespace StoreFrontUK.Services.EmailService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    [HttpPost("completed")]
    public async Task<IActionResult> SendOrderCompletedEmail(SendOrderCompletedEmailRequest request)
    {
        return await Task.FromResult(Ok($"Order Placed {request.Recipient}: {request.OrderId}"));
    }

    [HttpPost("awaiting-stock")]
    public async Task<IActionResult> SendAwaitingStockEmail(SendAwaitingStockEmailRequest request)
    {
        return await Task.FromResult(Ok($"Awaiting Stock... {request.Recipient}: {request.OrderId}"));
    }

    [HttpPost("out-of-stock")]
    public async Task<IActionResult> SendProductOutOfStockEmail(SendProductOutOfStockEmailRequest request)
    {
        return await Task.FromResult(Ok($"The following product is out of stock {request.Sku}"));
    }
}
