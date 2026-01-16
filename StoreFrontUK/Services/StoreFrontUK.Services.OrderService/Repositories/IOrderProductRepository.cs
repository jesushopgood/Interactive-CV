using StoreFrontUK.Services.Common;
using StoreFrontUK.Services.Common.Repository;
using StoreFrontUK.Services.OrderService.Data;
using StoreFrontUK.Services.OrderService.Entities;

namespace StoreFrontUK.Services.OrderService.Repositories;

public interface IOrderProductRepository : IRepository<OrderDbContext, OrderProduct, long>
{
    Task AddOrderProduct(Order order, string sku);
}