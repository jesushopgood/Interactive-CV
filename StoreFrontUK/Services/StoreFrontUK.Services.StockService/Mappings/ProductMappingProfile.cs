using AutoMapper;
using StoreFrontUK.GlobalObjects.Inventory;
using StoreFrontUK.Services.PickService.Models;
using StoreFrontUK.Services.StockService.Entities;

namespace StoreFrontUK.Services.StockService.Mappings;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
        // CreateMap<CreateProductDTO, Product>()
        //     .ForMember(dest => dest.Sku, opt => opt.Ignore());

        CreateMap<InventoryItem, InventoryItemDTO>().ReverseMap();

        //CreateMap<PickOrderRequest, InternalPickOrderCommand>();
        CreateMap<PickOrderItem, PickResponseItem>();
        CreateMap<ProductDTO, CreateProductDTO>().ReverseMap();
        CreateMap<ProductDTO, UpdateProductDTO>().ReverseMap();
    }
}