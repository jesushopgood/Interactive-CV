using StoreFrontUK.Messaging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

public class RabbitMQListener : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _configuration;

    public RabbitMQListener(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        _serviceProvider = serviceProvider;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        //await RabbitMQService.Instance.InitializeAsync();
        
        // await RabbitMQService.Instance.StartConsumingSupplier<BertsBitsStockEvent>(bbe => bbe!.ExecuteAsync(_serviceProvider));
        // await RabbitMQService.Instance.StartConsumingSupplier<UncleNobbiesStockEvent>(bbe => bbe!.ExecuteAsync(_serviceProvider));
        // await RabbitMQService.Instance.StartConsumingSupplier<JunkFactoryStockEvent>(bbe => bbe!.ExecuteAsync(_serviceProvider));
        // await RabbitMQService.Instance.StartConsuming<SupplierResponseEvent>(sre => sre!.ExecuteAsync(_serviceProvider));
    }
}