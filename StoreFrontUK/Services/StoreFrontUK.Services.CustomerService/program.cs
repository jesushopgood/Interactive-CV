using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StoreFrontUK.Services.Common.Exceptions;
using StoreFrontUK.Services.CustomerService.Data;
using StoreFrontUK.Services.CustomerService.Mappings;
using StoreFrontUK.Services.CustomerService.Repository;
namespace StoreFrontUK.Services.CustomerService;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CustomerDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDb"), sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
                });
            });

            builder.Services.AddScoped<IServiceProvider, ServiceProvider>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddAutoMapper(typeof(CustomerMappingProfile));

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5173")
                            .AllowAnyHeader()
                            .AllowAnyMethod();

                    });
            });

            var app = builder.Build();
            app.UseCors(MyAllowSpecificOrigins);

            using (var scope = app.Services.CreateScope())
            {
                var customerDb = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();
                customerDb.Database.Migrate();
                CustomerSeeder.Seed(customerDb);
            }

            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    context.Response.ContentType = "application/json";
                    Console.WriteLine($"Exception: {exception?.Message}");

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

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapControllers();
            app.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR ERROR ERROR = {ex.Message}");
        }

    }
}