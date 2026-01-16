using StoreFrontUK.Services.ThirdParty.BertsBits.Data;
using StoreFrontUK.Services.ThirdParty.Entities;

namespace StoreFrontUK.Services.ThirdParty.Data;

public static class BertsBitsSeeder
{
    public static void Seed(BertsBitsDbContext bertsBitsDbContext)
    {
        if (!bertsBitsDbContext.StockItems.Any())
        {
            bertsBitsDbContext.StockItems.AddRange
            (
                new StockItem { Sku = "SK1", Price = 18.99M, StockLevel = 89 },
                new StockItem { Sku = "SK2", Price = 18.99M, StockLevel = 89 },
                new StockItem { Sku = "SK3", Price = 18.99M, StockLevel = 89 },
                new StockItem { Sku = "SK4", Price = 18.99M, StockLevel = 89 }
            );

            bertsBitsDbContext.SaveChanges();
        }
    }
}