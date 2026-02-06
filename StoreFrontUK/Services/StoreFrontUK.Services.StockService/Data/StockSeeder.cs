using StoreFrontUK.Services.StockService.Entities;

namespace StoreFrontUK.Services.StockService.Data;

public static class InventorySeeder
{
    public static void Seed(StockDbContext context)
    {
        if (!context.Products.Any())
        {
            context.Products.AddRange
            (
                new Product { Sku = "SK1", Description = "Widgets", CanReorder = false },
                new Product { Sku = "SK2", Description = "Wotsits" },
                new Product { Sku = "SK3", Description = "Wangers" }
            );
        }

        if (!context.InventoryItems.Any())
        {
            context.InventoryItems.AddRange
            (
                new InventoryItem { ProductSku = "SK1", StockLevel = 99, Price = 100.00M },
                new InventoryItem { ProductSku = "SK2", StockLevel = 100, Price = 22.00M },
                new InventoryItem { ProductSku = "SK3", StockLevel = 77, Price = 12.00M }
            );
        }

        context.SaveChanges();
    }
}