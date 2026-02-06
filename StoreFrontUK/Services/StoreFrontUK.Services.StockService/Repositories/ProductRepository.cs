using StoreFrontUK.Services.Common.Repository;
using StoreFrontUK.Services.StockService.Data;
using StoreFrontUK.Services.StockService.Entities;

namespace StoreFrontUK.Services.InventoryService.Repostories;

public class ProductRepository : Repository<StockDbContext, Product, string>, IProductRepository
{
    public ProductRepository(StockDbContext context) : base(context)
    {
    }

    public async Task<List<Product>> GetProductsFromSkus(List<string> skus)
    {
        return await Task.FromResult(_context.Products.Where(p => skus.Contains(p.Sku)).ToList());
    }
}