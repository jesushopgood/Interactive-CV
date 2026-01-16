using Microsoft.AspNetCore.Builder;

namespace StoreFrontUK.GlobalObjects;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
    }
}