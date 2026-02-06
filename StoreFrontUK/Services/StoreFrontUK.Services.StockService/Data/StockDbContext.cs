using Microsoft.EntityFrameworkCore;
using StoreFrontUK.Services.StockService.Entities;

namespace StoreFrontUK.Services.StockService.Data;

public interface IStockDbContext
{
    DbSet<Product> Products { get; set; }

    public DbSet<InventoryItem> InventoryItems { get; set; }
}

public class StockDbContext : DbContext, IStockDbContext
{
    public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<InventoryItem> InventoryItems { get; set; }
}