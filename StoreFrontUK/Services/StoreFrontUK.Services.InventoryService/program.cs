using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreFrontUK.HttpClients;
using StoreFrontUK.Messaging;
using StoreFrontUK.Messaging.Events;
using StoreFrontUK.Messaging.Extensions;
using StoreFrontUK.Messaging.Interfaces;
using StoreFrontUK.Services.Common.Exceptions;
using StoreFrontUK.Services.InventoryService.Data;
using StoreFrontUK.Services.InventoryService.EventHandlers;
using StoreFrontUK.Services.InventoryService.Mappings;
using StoreFrontUK.Services.InventoryService.Repostories;

namespace StoreFrontUK.Services.InventoryService;

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

            builder.Services.AddDbContext<InventoryDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("ProductDb");
                Console.WriteLine($"Product Db Conn = {connectionString}");
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
                });
            });

            builder.Services.AddMessaging();
            builder.Services.AddTransient<IInventoryDbContext, InventoryDbContext>();
            builder.Services.AddScoped<ProductAddedEventHandler>();
            builder.Services.AddScoped<ProductOutOfStockEventHandler>();
            builder.Services.AddScoped<InventoryServiceClient>();
            builder.Services.AddScoped<IServiceProvider, ServiceProvider>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
            builder.Services.AddScoped<IAsyncEventProcessor<ProductAddedEvent>, ProductAddedEventHandler>();
            builder.Services.AddScoped<IAsyncEventProcessor<ProductOutOfStockEvent>, ProductOutOfStockEventHandler>();

            builder.Services.AddAutoMapper(typeof(ProductMappingProfile));

            builder.Services.AddHttpClient<EmailServiceClient>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ServiceUrls:EmailServiceClient"]!);
            });

            builder.Services.AddHttpClient<InventoryServiceClient>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ServiceUrls:InventoryServiceClient"]!);
            });
            
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var productDb = scope.ServiceProvider.GetRequiredService<InventoryDbContext>();
                productDb.Database.Migrate();
                InventorySeeder.Seed(productDb);
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
            await app.Consume(typeof(ProductAddedEvent), typeof(ProductOutOfStockEvent));
            app.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured {ex.Message}");
        }
    }
}