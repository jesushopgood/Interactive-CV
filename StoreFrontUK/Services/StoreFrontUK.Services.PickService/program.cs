using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StoreFrontUK.HttpClients;
using Microsoft.Extensions.Hosting;
using StoreFrontUK.Services.PickService.Mappings;
using StoreFrontUK.Messaging;

namespace StoreFrontUK.Services.PickService;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var builder = Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
            {
                services.AddSingleton<RabbitMQService>();
                services.AddAutoMapper(typeof(PickServiceMappingProfile).Assembly);
                
                services.AddHttpClient<InventoryServiceClient>(client =>
                {
                    client.BaseAddress = new Uri("http://localhost:5001/api/Inventory/");
                });
            });

            var app = builder.Build();
            app.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured {ex.Message}");
        }
    }
}