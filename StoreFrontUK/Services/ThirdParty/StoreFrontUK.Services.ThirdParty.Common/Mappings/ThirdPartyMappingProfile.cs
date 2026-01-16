using AutoMapper;
using StoreFrontUK.Messaging.Events;
using StoreFrontUK.Services.PickService.Requests;

namespace StoreFrontUK.Services.ThirdParty.Mappings;

public class ThirdPartyMappingProfile : Profile
{
    public ThirdPartyMappingProfile()
    {
        CreateMap<PickOrderRequest, BaseThirdPartyEvent>();    
    }
}