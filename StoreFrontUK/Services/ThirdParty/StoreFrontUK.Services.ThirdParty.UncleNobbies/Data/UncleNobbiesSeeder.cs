using StoreFrontUK.Services.ThirdParty.UncleNobbies.Entities;

namespace StoreFrontUK.Services.ThirdParty.UncleNobbies.Data;

public static class UncleNobbiesSeeder
{
    public static void Seed(UncleNobbiesDbContext uncleNobbiesDbContext)
    {
        if (!uncleNobbiesDbContext.StockUnits.Any())
        {
            uncleNobbiesDbContext.StockUnits.AddRange
            (
                new StockUnit { Sku = "SK1", SalePrice = 12.99M, StockCount = 16 },
                new StockUnit { Sku = "SK3", SalePrice = 31.99M, StockCount = 56 },
                new StockUnit { Sku = "SK4", SalePrice = 16.99M, StockCount = 12 },
                new StockUnit { Sku = "SK5", SalePrice = 19.99M, StockCount = 111 }
            );

            uncleNobbiesDbContext.SaveChanges();
        }
    }
}