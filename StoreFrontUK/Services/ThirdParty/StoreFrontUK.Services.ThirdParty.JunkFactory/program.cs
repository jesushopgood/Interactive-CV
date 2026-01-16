using Microsoft.AspNetCore.Builder;

namespace StoreFrontUK.Services.ThirdParty.JunkFactory;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured {ex.Message}");
        }
    }
}