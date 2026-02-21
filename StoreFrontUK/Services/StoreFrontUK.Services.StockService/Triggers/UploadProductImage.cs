using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace StoreFrontUK.Services.StockService.Triggers;

public class UploadProductImage
{
    private readonly ILogger<UploadProductImage> _logger;

    public UploadProductImage(ILogger<UploadProductImage> logger)
    {
        _logger = logger;
    }

    [Function("UploadProductImage")]
    public async Task Run([BlobTrigger("incoming/{folder}/{name}", Connection = "AzureWebJobsStorage")] byte[] image, string folder, string name)
    {
        _logger.LogInformation($"Uploaded image {name} in folder {folder} of size ${image.Length} bytes. ");
    }
}