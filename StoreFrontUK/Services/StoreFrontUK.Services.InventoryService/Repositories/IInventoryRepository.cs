using StoreFrontUK.GlobalObjects.PickService.Responses;
using StoreFrontUK.Services.Common.Repository;
using StoreFrontUK.Services.InventoryService.Data;
using StoreFrontUK.Services.InventoryService.Entities;
using StoreFrontUK.Services.PickService.Models;

namespace StoreFrontUK.Services.InventoryService.Repostories;
public interface IInventoryRepository : IRepository<InventoryDbContext, InventoryItem, string>
{
    Task<PickOrderResponse> PickOrder(List<PickOrderItem> items);
}