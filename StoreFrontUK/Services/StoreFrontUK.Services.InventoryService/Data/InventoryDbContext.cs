using Microsoft.EntityFrameworkCore;
using StoreFrontUK.Services.InventoryService.Entities;

namespace StoreFrontUK.Services.InventoryService.Data;

public interface IInventoryDbContext
{
    DbSet<Product> Products { get; set; }

    public DbSet<InventoryItem> InventoryItems { get; set; }
}

public class InventoryDbContext : DbContext, IInventoryDbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<InventoryItem> InventoryItems { get; set; }
}