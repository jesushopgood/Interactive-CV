using Microsoft.EntityFrameworkCore;
using StoreFrontUK.Services.Common;
using StoreFrontUK.Services.Common.Repository;
using StoreFrontUK.Services.OrderService.Data;
using StoreFrontUK.Services.OrderService.Entities;

namespace StoreFrontUK.Services.OrderService.Repositories;

public class OrderProductRepository : Repository<OrderDbContext, OrderProduct, long>, IOrderProductRepository
{
    public OrderProductRepository(OrderDbContext context) : base(context)
    {
    }

    public async Task AddOrderProduct(Order order, string sku)
    {
        var result = await _context.OrderProducts.FirstOrDefaultAsync(op => op.OrderId == order.OrderId && op.Sku == sku);
        if (result is null)
            _context.OrderProducts.Add(new OrderProduct { Order = order, Sku = sku });
        await _context.SaveChangesAsync();
    }
}