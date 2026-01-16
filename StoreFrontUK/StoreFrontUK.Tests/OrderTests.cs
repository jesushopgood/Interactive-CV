using AutoMapper;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Moq.Protected;
using System.Net;
using Moq;
using MediatR;
using StoreFrontUK.Services.OrderService.Data;
using StoreFrontUK.Services.OrderService.Entities;
using StoreFrontUK.Services.CustomerService.Mappings;
using StoreFrontUK.Services.OrderService.QueryHandlers;
using StoreFrontUK.Services.OrderService.Queries;
using StoreFrontUK.Services.OrderService.CommandHandlers;
using StoreFrontUK.HttpClients;
using StoreFrontUK.Services.OrderService.Commands;
using StoreFrontUK.Services.OrderService.Repositories;
using StoreFrontUK.Services.Common.Exceptions;

namespace StoreFrontUK.StoreFrontUK.Tests;

public class OrderTests : IDisposable
{
    private readonly IMapper _mapper;
    private readonly OrderDbContext _context;

    private readonly HttpClient _httpClient;

    private readonly Mock<IMediator> _mediatrMock;

    private readonly Mock<IOrderRepository> _orderRepository;

    private readonly Mock<IOrderProductRepository> _orderProductRepository;

    public OrderTests()
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        SetupHandlerMock(handlerMock);

        _httpClient = new HttpClient(handlerMock.Object)
        {
            BaseAddress = new Uri("http://fake-service")
        };

        var seededOrders = new List<Order>
        {
            new() { OrderItems = [new OrderItem{ Sku = "SK1", Quantity = 1 },
                                  new OrderItem{ Sku = "SK2", Quantity = 1 }],
                                  CustomerId = "1A", OrderId = 1 },
            new() { OrderItems = [new OrderItem{ Sku = "SK1", Quantity = 1 },
                                  new OrderItem{ Sku = "SK3", Quantity = 1 }],
                                  CustomerId = "2A", OrderId = 2 },
            new()  { OrderItems = [],CustomerId = "2A", OrderId = 3 },
        };

        var options = new DbContextOptionsBuilder<OrderDbContext>()
                            .UseInMemoryDatabase("TestDb")
                            .Options;

        _context = new OrderDbContext(options);
        _context.Orders.AddRange(seededOrders);
        _context.SaveChanges();

        _orderRepository = new Mock<IOrderRepository>();
        _orderProductRepository = new Mock<IOrderProductRepository>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<OrderMappingProfile>();
        });

        _mapper = config.CreateMapper();
        _mediatrMock = new Mock<IMediator>();
    }

    private static void SetupHandlerMock(Mock<HttpMessageHandler> handlerMock)
    {
        handlerMock
                    .Protected()
                    .Setup<Task<HttpResponseMessage>>(
                        "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("true")
                });
    }

    [Fact]
    public async Task AllOrders_Return_Seeded_Orders()
    {
        //Arrange
        var handler = new GetAllOrdersQueryHandler(_mapper, _orderRepository.Object);
        var query = new GetAllOrdersQuery();
        //Act
        var result = await handler.Handle(query, CancellationToken.None);
        //Assert
        Assert.True(result.Count == 3);
        Assert.True(result.Single(x => x.OrderId == 1).CustomerId == "1A");
    }

    [Fact]
    public async Task GetSingleExistingOrder()
    {
        //Arrange
        var handler = new GetOrderQueryHandler(_mapper, _orderRepository.Object);
        var query = new GetOrderQuery { OrderId = 1 };

        //Act
        var result = await handler.Handle(query, CancellationToken.None);

        //Assert
        Assert.True(result.CustomerId == "1A");
    }

    [Fact]
    public async Task GetSingleOrderNotExisting()
    {
        //Arrange
        var handler = new GetOrderQueryHandler(_mapper, _orderRepository.Object);
        var query = new GetOrderQuery { OrderId = 4 };

        //Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(query, CancellationToken.None));
    }

    [Fact]
    public async Task GetProductsOnExistingOrder()
    {
        //Arrange
        var handler = new GetOrderItemsOnOrderQueryHandler(_mapper, _orderRepository.Object);
        var query = new GetOrderItemsOnOrderQuery { OrderId = 1 };

        //Act
        var result = await handler.Handle(query, CancellationToken.None);

        //Assert
        Assert.True(result.Count == 2);
    }

    [Fact]
    public async Task GetProductsOnNotExistingOrder()
    {
        //Arrange
        var handler = new GetOrderItemsOnOrderQueryHandler(_mapper, _orderRepository.Object);
        var query = new GetOrderItemsOnOrderQuery { OrderId = 10 };

        //Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(query, CancellationToken.None));
    }

    [Fact]
    public async Task AddCustomerToOrderWithValidOrder()
    {
        //Arrange
        var handler = new AddCustomerToOrderCommandHandler(_mapper, _orderRepository.Object, new CustomerServiceClient(_httpClient));
        long orderId = 3;
        var customerId = "2A";

        var query = new AddCustomerToOrderCommand { OrderId = orderId, CustomerId = customerId };

        //Act
        await handler.Handle(query, CancellationToken.None);

        //Assert
        Assert.True(_context.Orders.Find(orderId)!.CustomerId == customerId);

    }

    [Fact]
    public async Task AddProductToOrder_WhenEmptySkuList()
    {
        //Arrange
        long orderId = 3;
        string sku = "SK10";

        var handler = new AddProductToOrderCommandHandler(
            _mapper,
            _orderRepository.Object,
            _orderProductRepository.Object,
            new InventoryServiceClient(_httpClient),
            _mediatrMock.Object);
            
        var query = new AddProductToOrderCommand { OrderId = orderId, Sku = sku };

        //Act
        await handler.Handle(query, CancellationToken.None);

        //Assert
        Assert.Single(_context.Orders.Find(orderId)!.OrderItems!);
    }

    [Fact]
    public async Task CreateNewOrderCommand()
    {
        //Arrange
        long orderId = 4; 
        var handler = new CreateNewOrderCommandHandler(_mapper, _orderRepository.Object);
        var query = new CreateNewOrderCommand { IsBasketOrder = false };

        //Act
        await handler.Handle(query, CancellationToken.None);

        //Assert
        Assert.True(_context.Orders.Find(orderId) is not null);
    }

    public void Dispose()
    {
        _context.Orders.RemoveRange(_context.Orders);
        _context.SaveChanges();
    }
}
