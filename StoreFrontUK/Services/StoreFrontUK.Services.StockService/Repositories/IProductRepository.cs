using StoreFrontUK.Services.Common;
using StoreFrontUK.Services.Common.Repository;
using StoreFrontUK.Services.StockService.Data;
using StoreFrontUK.Services.StockService.Entities;

namespace StoreFrontUK.Services.InventoryService.Repostories;

public interface IProductRepository : IRepository<StockDbContext, Product, string>
{
    Task<List<Product>> GetProductsFromSkus(List<string> skus);
}