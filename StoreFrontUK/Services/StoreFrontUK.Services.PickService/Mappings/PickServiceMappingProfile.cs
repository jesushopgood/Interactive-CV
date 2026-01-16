using AutoMapper;
using StoreFrontUK.Messaging.Events;
using StoreFrontUK.Services.PickService.Requests;

namespace StoreFrontUK.Services.PickService.Mappings;

public class PickServiceMappingProfile : Profile
{
    public PickServiceMappingProfile()
    {
        CreateMap<PickOrderRequest, BaseThirdPartyEvent>().ReverseMap();
    }
}