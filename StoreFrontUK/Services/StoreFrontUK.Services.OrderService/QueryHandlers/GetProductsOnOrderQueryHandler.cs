using MediatR;
using StoreFrontUK.HttpClients;
using StoreFrontUK.Services.OrderService.Queries;
using StoreFrontUK.Services.OrderService.Repositories;
using StoreFrontUK.GlobalObjects.Inventory;
using StoreFrontUK.Services.Common.Exceptions;

public class GetProductsOnOrderQueryHandler : IRequestHandler<GetProductsOnOrderQuery, List<ProductDTO>>
{
    private readonly InventoryServiceClient _productServiceClient;
    private readonly IOrderRepository _orderRespository;

    public GetProductsOnOrderQueryHandler(InventoryServiceClient productServiceClient, IOrderRepository orderRepository)
    {
        _productServiceClient = productServiceClient;
        _orderRespository = orderRepository;
    }

    public async Task<List<ProductDTO>> Handle(GetProductsOnOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRespository.GetById(request.OrderId, o => o.OrderId, [o => o.OrderItems]);
        if (order is null)
            throw new NotFoundException($"Unable to find order {request.OrderId}");

        var productSkus = order.OrderItems.Select(oi => oi.Sku).Distinct().ToList();

        if (!productSkus.Any())
            return await Task.FromResult(new List<ProductDTO>());

        return await _productServiceClient.GetProductsOnOrder(productSkus);
    }
}