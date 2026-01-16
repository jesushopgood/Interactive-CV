using StoreFrontUK.Services.Common.Exceptions;
using StoreFrontUK.Services.Common.Repository;
using StoreFrontUK.Services.OrderService.Data;
using StoreFrontUK.Services.OrderService.Entities;

namespace StoreFrontUK.Services.OrderService.Repositories;

public class OrderRepository : TransactionalRepository<OrderDbContext, Order, long>, IOrderRepository
{
    public OrderRepository(OrderDbContext context) : base(context)
    {
    }

    public async Task AddCustomerToOrder(long orderId, string customerId)
    {
        var order = await GetById(orderId, o => o.OrderId);
        if (order is null)
            throw new NotFoundException($"Cannot find Order: {orderId}");

        order.CustomerId = customerId;
        await _context.SaveChangesAsync();
    }
}