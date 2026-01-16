using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreFrontUK.Messaging;
using StoreFrontUK.Services.ThirdParty.BertsBits.Data;
using StoreFrontUK.Services.ThirdParty.Data;

namespace StoreFrontUK.Services.ThirdParty.BertsBits;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            builder.Services.AddDbContext<BertsBitsDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BertsBitsDb")));

            builder.Services.AddHostedService<RabbitMQListener>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var bertsBitsDb = scope.ServiceProvider.GetRequiredService<BertsBitsDbContext>();
                BertsBitsSeeder.Seed(bertsBitsDb);
            }
            app.Run();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured {ex.Message}");
        }
    }
}