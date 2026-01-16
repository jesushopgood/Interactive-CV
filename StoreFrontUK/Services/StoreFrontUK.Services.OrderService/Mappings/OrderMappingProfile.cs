using AutoMapper;
using StoreFrontUK.GlobalObjects.Order;
using StoreFrontUK.Messaging.Events;
using StoreFrontUK.Services.OrderService.Entities;
using StoreFrontUK.Services.PickService.Models;
using StoreFrontUK.Services.PickService.Requests;

namespace StoreFrontUK.Services.CustomerService.Mappings;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<OrderItem, OrderItemDTO>().ReverseMap();

        CreateMap<Order, OrderDTO>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems))
            .ReverseMap();

        CreateMap<OrderItemDTO, PickOrderItem>()
            .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Sku))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

        CreateMap<PickOrderRequest, BaseThirdPartyEvent>().ReverseMap();
    }
}