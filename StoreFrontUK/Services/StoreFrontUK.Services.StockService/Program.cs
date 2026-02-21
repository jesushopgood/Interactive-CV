using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StoreFrontUK.Services.StockService.Data;
using StoreFrontUK.Services.StockService.Repostories;
using StoreFrontUK.Services.StockService.Mappings;
using Microsoft.Extensions.Configuration;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        // Register MediatR and scan the current assembly for handlers
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });

        services.AddDbContextPool<StockDbContext>(options =>
        {
            var config = context.Configuration;

            options.UseSqlServer(config["ProductDb"], sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null);
                sqlOptions.MigrationsAssembly(typeof(StockDbContext).Assembly.FullName);
            });
        });

        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddAutoMapper(typeof(ProductMappingProfile));
    })
    .Build();

host.Run();