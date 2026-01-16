using Microsoft.EntityFrameworkCore;
using StoreFrontUK.Services.OrderService.Data;
using StoreFrontUK.Services.OrderService.Entities;

public static class OrderSeeder
{
    public static void Seed(OrderDbContext context)
    {
        if (!context.Orders.Any())
        {
            var order1 = new Order
            {
                OrderItems = [new() { Sku = "SK1", Quantity = 2 }, new() { Sku = "SK2", Quantity = 1 }],
                CustomerId = "1AA",
            };

            var order2 = new Order
            {
                OrderItems = [new() { Sku = "SK2", Quantity = 2 }, new() { Sku = "SK3", Quantity = 1 }],
                CustomerId = "2AA",
            };

            var order3 = new Order
            {
                OrderItems = [],
                CustomerId = "3AA",
            };

            context.Orders.AddRange(order1, order2, order3);

            context.OrderProducts.AddRange
            (
                new OrderProduct { Order = order1, Sku = "SK1" },
                new OrderProduct { Order = order1, Sku = "SK2" },
                new OrderProduct { Order = order2, Sku = "SK2" },
                new OrderProduct { Order = order2, Sku = "SK3" }
            );

            context.SaveChanges();
        }
    }
}