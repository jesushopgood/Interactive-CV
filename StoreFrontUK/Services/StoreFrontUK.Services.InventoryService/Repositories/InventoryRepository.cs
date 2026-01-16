using StoreFrontUK.GlobalObjects.PickService.Enums;
using StoreFrontUK.GlobalObjects.PickService.Responses;
using StoreFrontUK.Services.Common.Repository;
using StoreFrontUK.Services.InventoryService.Data;
using StoreFrontUK.Services.InventoryService.Entities;
using StoreFrontUK.Services.PickService.Models;

namespace StoreFrontUK.Services.InventoryService.Repostories;

public class InventoryRepository : Repository<InventoryDbContext, InventoryItem, string>, IInventoryRepository
{
    private readonly PickOrderResponse _pickOrderResponse;

    public InventoryRepository(InventoryDbContext context) : base(context)
    {
        _pickOrderResponse = new PickOrderResponse { PickResult = StockPickResult.SatisfiedInternally };
    }

    public async Task<PickOrderResponse> PickOrder(List<PickOrderItem> pickOrderItems)
    {
        pickOrderItems.ForEach(UpdateInventory);
        await _context.SaveChangesAsync();
        return await Task.FromResult(_pickOrderResponse);
    }

    public void UpdateInventory(PickOrderItem item)
    {
        var inventoryItem = _context
                            .InventoryItems
                            .Single(ie => ie.ProductSku == item.Sku);

        if (inventoryItem.StockLevel >= item.Quantity)
        {
            inventoryItem.StockLevel -= item.Quantity;
            _pickOrderResponse.OrderItems.Add(item);
        }
        else
        {
            item.Quantity = inventoryItem.StockLevel;
            inventoryItem.StockLevel = 0;
            _pickOrderResponse.PickResult = StockPickResult.PartialSuccess;
            _pickOrderResponse.OrderItems.Add(item);
        }
    }
}