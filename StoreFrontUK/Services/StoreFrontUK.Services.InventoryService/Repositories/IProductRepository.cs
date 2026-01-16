using StoreFrontUK.Services.Common;
using StoreFrontUK.Services.Common.Repository;
using StoreFrontUK.Services.InventoryService.Data;
using StoreFrontUK.Services.InventoryService.Entities;

namespace StoreFrontUK.Services.InventoryService.Repostories;

public interface IProductRepository : IRepository<InventoryDbContext, Product, string>
{
    Task<List<Product>> GetProductsFromSkus(List<string> skus);
}