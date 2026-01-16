using StoreFrontUK.Services.ThirdParty.JunkFactory;
using StoreFrontUK.Services.ThirdParty.JunkFactory.Entities;

namespace StoreFrontUK.Services.ThirdParty.JunkFactory.Data;

public static class JunkFactorySeeder
{
    public static void Seed(JunkFactoryDbContext junkFactoryDbContext)
    {
        if (!junkFactoryDbContext.Products.Any())
        {
            junkFactoryDbContext.Products.AddRange
            (
                new Product { Sku = "SK1", PricePerUnit = 18.99M, QuantityInStock = 454 },
                new Product { Sku = "SK2", PricePerUnit = 10.99M, QuantityInStock = 200 },
                new Product { Sku = "SK3", PricePerUnit = 21.99M, QuantityInStock = 780 }
            );

            junkFactoryDbContext.SaveChanges();
        }
    }
}