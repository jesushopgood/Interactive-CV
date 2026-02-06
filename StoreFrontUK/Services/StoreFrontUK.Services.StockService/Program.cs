using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using StoreFrontUK.Services.InventoryService.Repostories;
using Microsoft.EntityFrameworkCore;
using StoreFrontUK.Services.StockService.Data;
using StoreFrontUK.Services.InventoryService.Mappings;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        // Register MediatR and scan the current assembly for handlers
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
        });

        services.AddDbContextPool<StockDbContext>(options =>
        {
            options.UseSqlServer("dummyString", sqlOptions =>
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