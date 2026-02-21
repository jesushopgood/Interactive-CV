using Microsoft.Azure.Functions.Worker;

using Microsoft.Extensions.Logging;

namespace StoreFrontUK.Services.StockService.Triggers;

public class ProcessApprovedImage
{
    private readonly ILogger<ProcessApprovedImage> _logger;

    public ProcessApprovedImage(ILogger<ProcessApprovedImage> logger)
    {
        _logger = logger;
    }

    [Function("ProcessApprovedImage")]
    public void Run(
    [QueueTrigger("approved-images", Connection = "AzureWebJobsStorage")] string message)
    {
        _logger.LogInformation($"Queue message received: {message}");
    }

}