using StoreFrontUK.Services.Common.Repository;
using StoreFrontUK.Services.InventoryService.Data;
using StoreFrontUK.Services.InventoryService.Entities;

namespace StoreFrontUK.Services.InventoryService.Repostories;

public class ProductRepository : Repository<InventoryDbContext, Product, string>, IProductRepository
{
    public ProductRepository(InventoryDbContext context) : base(context)
    {
    }

    public async Task<List<Product>> GetProductsFromSkus(List<string> skus)
    {
        return await Task.FromResult(_context.Products.Where(p => skus.Contains(p.Sku)).ToList());
    }
}