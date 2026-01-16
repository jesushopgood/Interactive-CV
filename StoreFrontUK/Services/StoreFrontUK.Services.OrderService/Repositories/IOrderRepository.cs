using System.Linq.Expressions;
using StoreFrontUK.Services.Common;
using StoreFrontUK.Services.Common.Repository;
using StoreFrontUK.Services.OrderService.Data;
using StoreFrontUK.Services.OrderService.Entities;

namespace StoreFrontUK.Services.OrderService.Repositories;

public interface IOrderRepository : ITransactionalRepository<OrderDbContext, Order, long>
{
    Task AddCustomerToOrder(long orderId, string customerId);
}