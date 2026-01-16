using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreFrontUK.Services.OrderService.Data;
using StoreFrontUK.HttpClients;
using StoreFrontUK.Services.Common.Exceptions;
using StoreFrontUK.Messaging;
using Microsoft.EntityFrameworkCore;
using StoreFrontUK.Services.OrderService.Repositories;
using StoreFrontUK.Services.CustomerService.Mappings;
using StoreFrontUK.Services.OrderService.Events;
using StoreFrontUK.Services.PickService;
using StoreFrontUK.Services.OrderService.EventHandlers;
using StoreFrontUK.Messaging.Extensions;
using StoreFrontUK.Messaging.Interfaces;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace StoreFrontUK.Services.OrderService;

internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<RabbitMQService>();

            builder.Services.AddDbContext<OrderDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("OrderDb");
                Console.WriteLine($"Order Db Conn = {connectionString}");
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
                });
            });

            builder.Services.AddMessaging();
            builder.Services.AddScoped<IServiceProvider, ServiceProvider>();            
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderProductRepository, OrderProductRepository>();
            builder.Services.AddScoped<IPickService, PickService.PickService>();
            builder.Services.AddScoped<IAsyncEventProcessor<OrderCompletedEvent>, OrderCompletedEventHandler>();

            builder.Services.AddAutoMapper(typeof(OrderMappingProfile));

            builder.Services.AddHttpClient<CustomerServiceClient>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ServiceUrls:CustomerServiceClient"]!);
            });

            builder.Services.AddHttpClient<InventoryServiceClient>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ServiceUrls:InventoryServiceClient"]!);
            });

            builder.Services.AddHttpClient<OrderServiceClient>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ServiceUrls:OrderServiceClient"]!);
            });

            builder.Services.AddHttpClient<EmailServiceClient>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ServiceUrls:EmailServiceClient"]!);
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var orderDb = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
                orderDb.Database.Migrate();
                OrderSeeder.Seed(orderDb);
            }

            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    context.Response.ContentType = "application/json";

                    context.Response.StatusCode = exception switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        AlreadyExistsException => StatusCodes.Status409Conflict,
                        OutOfStockException => StatusCodes.Status409Conflict,
                        InvalidStateException => StatusCodes.Status409Conflict,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    if (context.Response.StatusCode == StatusCodes.Status500InternalServerError)
                    {
                        context.Response.StatusCode = exception?.InnerException switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            AlreadyExistsException => StatusCodes.Status409Conflict,
                            OutOfStockException => StatusCodes.Status409Conflict,
                            InvalidStateException => StatusCodes.Status409Conflict,
                            _ => StatusCodes.Status500InternalServerError
                        };
                    }

                    var errorResponse = new { error = exception?.Message };
                    await context.Response.WriteAsJsonAsync(errorResponse);
                });
            });

            app.MapControllers();
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI();

            await RabbitMQService.Instance.InitializeAsync(builder.Configuration["RabbitMQService"]!);
            await app.Consume(typeof(OrderCompletedEvent));
            app.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured {ex.Message}");
        }
    }
}